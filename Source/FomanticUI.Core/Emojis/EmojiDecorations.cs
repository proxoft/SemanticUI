using static Proxoft.FomanticUI.Core.EmojiDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum EmojiDecorations
{
    NoDecoration = 0,
    Link = 1 << 0,
    Loading = 1 << 1,
    Disabled = 1 << 2
}

public static class EmojiDecorationsExtensions
{
    private static readonly EmojiDecorations[] _allValues = Enum.GetValues(typeof(EmojiDecorations))
        .Cast<EmojiDecorations>()
        .ToArray();

    public static string ToClass(this EmojiDecorations decorations)
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

    private static string ValueToClass(this EmojiDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}