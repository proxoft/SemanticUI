using System;
using static Proxoft.SemanticUI.Core.DimmerDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum DimmerDecorations
    {
        NoDecoration = 0,
        Page         = 1 << 0,
        Inverted     = 1 << 1,
        Blurring     = 1 << 2
    }

    public static class DimmerDecorationsExtensions
    {
        public static string ToClass(this DimmerDecorations decoration)
        {
            if (decoration == NoDecoration)
            {
                return string.Empty;
            }

            var classes = new string[] {
                "page".ToClassIf(decoration.HasFlag(Page)),
                "inverted".ToClassIf(decoration.HasFlag(Inverted)),
            };

            return classes.ToClass();
        }
    }
}
