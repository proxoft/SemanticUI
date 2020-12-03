using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.ListDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum ListDecorations
    {
        NoDecoration = 0,
        Animated     = 1 << 0,
        Bulleted     = 1 << 1,
        Celled       = 1 << 2,
        Divided      = 1 << 3,
        Inverted     = 1 << 4,
        Link         = 1 << 5,
        Ordered      = 1 << 6,
        Relaxed      = 1 << 7,
        VeryRelaxed  = 1 << 8,
        Selection    = 1 << 9,
    }

    public static class ListDecorationsExtensions
    {
        private static readonly ListDecorations[] allValues = Enum.GetValues(typeof(ListDecorations))
                .Cast<ListDecorations>()
                .ToArray();

        public static string ToClass(this ListDecorations decorations)
        {
            var classes = allValues
                .Select(v =>
                {
                    return decorations.HasFlag(v)
                        ? v.ValueToClass()
                        : string.Empty;
                });

            return classes.ToClass();
        }

        private static string ValueToClass(this ListDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                VeryRelaxed => "very relaxed",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
