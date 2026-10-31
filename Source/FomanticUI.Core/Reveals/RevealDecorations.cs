using static Proxoft.FomanticUI.Core.RevealDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum RevealDecorations
{
    NoDecoration = 0,
    Instant = 1 << 0,
    Active = 1 << 1,
    Disabled = 1 << 2
}

public static class RevealDecorationsExtensions
{
    private static readonly RevealDecorations[] _allValues = Enum.GetValues(typeof(RevealDecorations))
        .Cast<RevealDecorations>()
        .ToArray();

    public static string ToClass(this RevealDecorations decorations)
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

    private static string ValueToClass(this RevealDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}