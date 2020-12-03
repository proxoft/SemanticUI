using System;

using static Proxoft.SemanticUI.Core.ButtonDecoration;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum ButtonDecoration
    {
        NoDecoration = 0,
        Basic        = 1 << 1,
        Compact      = 1 << 2,
        Icon         = 1 << 3,
        Labeled      = 1 << 4,
        Inverted     = 1 << 5,
        // Doesnt work for group
        Circular     = 1 << 6
    }

    public static class ButtonDecorationExtensions
    {
        public static string ToClass(this ButtonDecoration decoration)
        {
            if(decoration == NoDecoration)
            {
                return string.Empty;
            }

            var classes = new string[] {
                "basic".ToClassIf(decoration.HasFlag(Basic)),
                "compact".ToClassIf(decoration.HasFlag(Compact)),
                "labeled".ToClassIf(decoration.HasFlag(Labeled)),
                "icon".ToClassIf(decoration.HasFlag(Icon)),
                "inverted".ToClassIf(decoration.HasFlag(Inverted)),
                "circular".ToClassIf(decoration.HasFlag(Circular))
            };

            return classes.ToClass();
        }
    }
}
