using static Proxoft.FomanticUI.Core.AdDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum AdDecorations
{
    NoDecoration = 0,
    Centered = 1 << 0,
    Test = 1 << 1,
    Mobile = 1 << 2
}

public static class AdDecorationsExtensions
{
    private static readonly AdDecorations[] _allValues = Enum.GetValues(typeof(AdDecorations))
        .Cast<AdDecorations>()
        .ToArray();

    public static string ToClass(this AdDecorations decorations)
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

    private static string ValueToClass(this AdDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}