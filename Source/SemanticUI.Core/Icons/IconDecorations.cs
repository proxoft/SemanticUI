using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.IconDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum IconDecorations
    {
        NoDecoration             = 0,
        Link                     = 1 << 0,
        Inverted                 = 1 << 1,
        Disabled                 = 1 << 2,
        Loading                  = 1 << 3,
        Fitted                   = 1 << 4,
        Flipped                  = 1 << 5,
        RotatedClockwise         = 1 << 6,
        RotatedCounterClockwise  = 1 << 7,
        Circular                 = 1 << 8,
        Bordered                 = 1 << 9
    }

    public static class IconDecorationsExtensions
    {
        private static readonly IconDecorations[] _allValues = Enum.GetValues(typeof(IconDecorations))
                .Cast<IconDecorations>()
                .ToArray();

        public static string ToClass(this IconDecorations decorations)
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

        private static string ValueToClass(this IconDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                RotatedClockwise => "clockwise rotated",
                RotatedCounterClockwise => "counterclockwise rotated",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
