using static Proxoft.FomanticUI.Core.ItemsDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum ItemsDecorations
{
    NoDecoration = 0,
    Divided = 1 << 0,
    Relaxed = 1 << 1,
    VeryRelaxed = 1 << 2,
    Link = 1 << 3,
    Unstackable = 1 << 4,
    Inverted = 1 << 5,
    Disabled = 1 << 6
}

public static class ItemsDecorationsExtensions
{
    private static readonly ItemsDecorations[] _allValues = Enum.GetValues(typeof(ItemsDecorations))
        .Cast<ItemsDecorations>()
        .ToArray();

    public static string ToClass(this ItemsDecorations decorations)
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

    private static string ValueToClass(this ItemsDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            VeryRelaxed => "very relaxed",
            _ => value.ToString().ToLower()
        };
    }
}