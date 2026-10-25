using System.Globalization;

namespace Proxoft.FomanticUI.Core
{
    public sealed record ProgressBar(
        double Percent,
        string Width,
        bool IsVisible,
        bool IsTransparent,
        bool RoundLeft,
        bool RoundRight,
        string? Text,
        Color Color);

    public sealed record ProgressOptions(
        double? Total = null,
        int Decimals = 0,
        ProgressBarText BarText = ProgressBarText.Percent,
        string PercentFormat = "{percent}%",
        string RatioFormat = "{value} of {total}",
        IReadOnlyList<Color>? BarColors = null,
        CultureInfo? Culture = null);

    /// <summary>
    /// Bar widths, texts and states of a progress, computed the same way as Fomantic UI's progress module.
    /// </summary>
    public sealed class ProgressState
    {
        private ProgressState(IReadOnlyList<ProgressBar> bars, double percent, string dataPercent)
        {
            this.Bars = bars;
            this.Percent = percent;
            this.DataPercent = dataPercent;
        }

        public IReadOnlyList<ProgressBar> Bars { get; }

        /// <summary>
        /// Sum of all bars in percent, rounded to the requested decimals.
        /// </summary>
        public double Percent { get; }

        /// <summary>
        /// Value of the data-percent attribute (comma separated for multiple bars); the indicating variation colors by it.
        /// </summary>
        public string DataPercent { get; }

        public bool IsComplete => this.Percent >= 100;

        /// <summary>
        /// Fomantic marks a started but unfinished progress as active.
        /// </summary>
        public bool IsInProgress => this.Percent > 0 && this.Percent < 100;

        /// <summary>
        /// Calculates the bars for one or more values.
        /// Without a total the values are percents; with a total they are amounts of it.
        /// Values are clamped so that bars never go below 0 or above 100% in sum.
        /// </summary>
        public static ProgressState Calculate(IReadOnlyList<double> values, ProgressOptions options)
        {
            var culture = options.Culture ?? CultureInfo.CurrentCulture;
            var total = options.Total is > 0 ? options.Total : null;

            var percents = new List<double>(values.Count);
            var remaining = 100.0;
            foreach (var value in values)
            {
                var percent = total is { } t ? value / t * 100 : value;
                percent = double.IsNaN(percent) ? 0 : Math.Clamp(percent, 0, remaining);
                percents.Add(percent);
                remaining -= percent;
            }

            var isMultiple = percents.Count > 1;
            var allZero = percents.All(p => p == 0);
            var visible = percents
                .Select((p, i) => !isMultiple || p > 0 || (allZero && i == percents.Count - 1))
                .ToArray();
            var firstVisible = Array.IndexOf(visible, true);
            var lastVisible = Array.LastIndexOf(visible, true);

            var bars = percents
                .Select((p, i) => new ProgressBar(
                    Percent: Math.Round(p, options.Decimals),
                    Width: $"{p.ToString(CultureInfo.InvariantCulture)}%",
                    IsVisible: visible[i],
                    IsTransparent: isMultiple && allZero,
                    RoundLeft: i == firstVisible,
                    RoundRight: i == lastVisible,
                    Text: BarText(p, total, options, culture),
                    Color: options.BarColors is { } colors && i < colors.Count ? colors[i] : Color.NoColor))
                .ToArray();

            var dataPercent = string.Join(",", bars.Select(b => b.Percent.ToString(CultureInfo.InvariantCulture)));

            return new ProgressState(bars, Math.Round(percents.Sum(), options.Decimals), dataPercent);
        }

        private static string? BarText(double percent, double? total, ProgressOptions options, CultureInfo culture)
        {
            var format = options.BarText switch
            {
                ProgressBarText.None => null,
                ProgressBarText.Ratio when total is not null => options.RatioFormat,
                _ => options.PercentFormat
            };

            if (format is null)
            {
                return null;
            }

            var roundedPercent = Math.Round(percent, options.Decimals);
            var value = total is { } t ? Math.Round(percent / 100 * t, Math.Max(options.Decimals, 1)) : roundedPercent;
            var left = total is { } t2 ? Math.Round(t2 - value, Math.Max(options.Decimals, 1)) : Math.Round(100 - percent, options.Decimals);

            return format
                .Replace("{percent}", roundedPercent.ToString(culture))
                .Replace("{value}", value.ToString(culture))
                .Replace("{total}", (total ?? 100).ToString(culture))
                .Replace("{left}", left.ToString(culture));
        }
    }
}
