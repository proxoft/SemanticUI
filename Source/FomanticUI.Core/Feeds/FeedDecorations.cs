using static Proxoft.FomanticUI.Core.FeedDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum FeedDecorations
{
    NoDecoration = 0,
    Divided = 1 << 0,
    Connected = 1 << 1,
    Ordered = 1 << 2,
    Basic = 1 << 3,
    Inverted = 1 << 4,
    Disabled = 1 << 5
}

public static class FeedDecorationsExtensions
{
    private static readonly FeedDecorations[] _allValues = Enum.GetValues(typeof(FeedDecorations))
        .Cast<FeedDecorations>()
        .ToArray();

    public static string ToClass(this FeedDecorations decorations)
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

    private static string ValueToClass(this FeedDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}