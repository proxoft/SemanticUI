using static Proxoft.FomanticUI.Core.CommentsDecorations;

namespace Proxoft.FomanticUI.Core;

[Flags]
public enum CommentsDecorations
{
    NoDecoration = 0,
    Threaded = 1 << 0,
    Minimal = 1 << 1,
    Collapsed = 1 << 2,
    Inverted = 1 << 3,
    Disabled = 1 << 4
}

public static class CommentsDecorationsExtensions
{
    private static readonly CommentsDecorations[] _allValues = Enum.GetValues(typeof(CommentsDecorations))
        .Cast<CommentsDecorations>()
        .ToArray();

    public static string ToClass(this CommentsDecorations decorations)
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

    private static string ValueToClass(this CommentsDecorations value)
    {
        return value switch
        {
            NoDecoration => string.Empty,
            _ => value.ToString().ToLower()
        };
    }
}