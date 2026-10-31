using static Proxoft.FomanticUI.Core.PlaceholderDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum PlaceholderDecorations
{
    NoDecoration = 0,
    Fluid = 1 << 0,
    Inverted = 1 << 1
}

public static class PlaceholderDecorationsExtensions
{
    private static readonly PlaceholderDecorations[] _allValues = Enum.GetValues(typeof(PlaceholderDecorations))
        .Cast<PlaceholderDecorations>()
        .ToArray();

    public static string ToClass(this PlaceholderDecorations decorations)
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

    private static string ValueToClass(this PlaceholderDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}