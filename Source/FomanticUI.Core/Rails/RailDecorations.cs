using static Proxoft.FomanticUI.Core.RailDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum RailDecorations
{
    NoDecoration = 0,
    Internal = 1 << 0,
    Dividing = 1 << 1,
    Attached = 1 << 2,
    Close = 1 << 3,
    VeryClose = 1 << 4
}

public static class RailDecorationsExtensions
{
    private static readonly RailDecorations[] _allValues = Enum.GetValues(typeof(RailDecorations))
        .Cast<RailDecorations>()
        .ToArray();

    public static string ToClass(this RailDecorations decorations)
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

    private static string ValueToClass(this RailDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            VeryClose => "very close",
            _ => value.ToString().ToLower()
        };
    }
}