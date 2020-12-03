using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.SegmentDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum SegmentDecorations
    {
        NoDecoration = 0,
        Basic        = 1 << 0,
        Compact      = 1 << 1,
        Secondary    = 1 << 2,
        Tertiary     = 1 << 3,
        Disabled     = 1 << 4,
        Loading      = 1 << 5,
        Inverted     = 1 << 6,
        Stacked      = 1 << 7,
        Raised       = 1 << 8,
        Piled        = 1 << 9,
        Placeholder  = 1 << 10,
        Blurred      = 1 << 11,
        Padded       = 1 << 12,
        VeryPadded   = 1 << 13,
        Vertical     = 1 << 14,
        Circular     = 1 << 15,
        Clearing     = 1 << 16
    }

    public static class SegmentDecorationsExtensions
    {
        private static readonly SegmentDecorations[] _allValues = Enum.GetValues(typeof(SegmentDecorations))
                .Cast<SegmentDecorations>()
                .ToArray();

        public static string ToClass(this SegmentDecorations decorations)
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

        private static string ValueToClass(this SegmentDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                VeryPadded => "very padded",
                Blurred => "blurring dimmable dimmed",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
