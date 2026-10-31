using static Proxoft.FomanticUI.Core.ExtraDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum ExtraDecorations
{
    NoDecoration = 0,
    Text = 1 << 0,
    Images = 1 << 1
}

public static class ExtraDecorationsExtensions
{
    private static readonly ExtraDecorations[] _allValues = Enum.GetValues(typeof(ExtraDecorations))
        .Cast<ExtraDecorations>()
        .ToArray();

    public static string ToClass(this ExtraDecorations decorations)
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

    private static string ValueToClass(this ExtraDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}