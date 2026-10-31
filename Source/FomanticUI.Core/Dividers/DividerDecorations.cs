using static Proxoft.FomanticUI.Core.DividerDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum DividerDecorations
{
    NoDecoration = 0,
    Vertical = 1 << 0,
    Horizontal = 1 << 1,
    Inverted = 1 << 2,
    Fitted = 1 << 3,
    Hidden = 1 << 4,
    Section = 1 << 5,
    Clearing = 1 << 6
}

public static class DividerDecorationsExtensions
{
    private static readonly DividerDecorations[] _allValues = Enum.GetValues(typeof(DividerDecorations))
        .Cast<DividerDecorations>()
        .ToArray();

    public static string ToClass(this DividerDecorations decorations)
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

    private static string ValueToClass(this DividerDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}