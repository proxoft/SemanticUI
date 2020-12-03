using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static Proxoft.SemanticUI.Core.GridDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum GridDecorations
    {
        NoDecoration       = 0,
        Stackable          = 1 << 0,
        Doubling           = 1 << 1,
        Fluid              = 1 << 2,
        Divided            = 1 << 3,
        VerticallyDivided  = 1 << 4,
        Celled             = 1 << 5,
        InternalyCelled    = 1 << 6,
        EqualWidth         = 1 << 7,
        Padded             = 1 << 8,
        VerticallyPadded   = 1 << 9,
        HorizontallyPadded = 1 << 10,
        Relaxed            = 1 << 11,
        VeryRelaxed        = 1 << 12,
        Centered           = 1 << 13,
    }

    public static class GridDecorationsExtensions
    {
        private static readonly GridDecorations[] allValues = Enum.GetValues(typeof(GridDecorations))
                .Cast<GridDecorations>()
                .ToArray();

        public static string ToClass(this GridDecorations decorations)
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

        private static string ValueToClass(this GridDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                VerticallyPadded => "vertically padded",
                HorizontallyPadded => "horizontally padded",
                VeryRelaxed => "very relaxed",
                VerticallyDivided => "vertically divided",
                InternalyCelled => "internally celled",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
