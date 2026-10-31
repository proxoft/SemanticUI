using static Proxoft.FomanticUI.Core.ProgressDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum ProgressDecorations
{
    NoDecoration = 0,
    Indicating = 1 << 0,
    Basic = 1 << 1,
    Inverted = 1 << 2,
    Disabled = 1 << 3,
    Slow = 1 << 4,
    Fast = 1 << 5
}

public static class ProgressDecorationsExtensions
{
    private static readonly ProgressDecorations[] _allValues = Enum.GetValues(typeof(ProgressDecorations))
        .Cast<ProgressDecorations>()
        .ToArray();

    public static string ToClass(this ProgressDecorations decorations)
    {
        var classes = _allValues
            .Select(v =>
            {
                return decorations.HasFlag(v)
                    ? v.ValueToClass()
                    : string.Empty;
            });

        return classes.ToClass();
    }

    private static string ValueToClass(this ProgressDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}