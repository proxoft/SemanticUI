using System;
using System.Linq;
using static Proxoft.SemanticUI.Core.MenuDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum MenuDecorations
    {
        None       = 0,
        Icon       = 1 << 0,
        Labeled    = 1 << 1,
        Pointing   = 1 << 2,
        Inverted   = 1 << 3,
        Fixed      = 1 << 4,
        Fluid      = 1 << 5,
        Compact    = 1 << 6,
        Borderless = 1 << 7
    }

    public static class MenuDecorationsExtensions
    {
        private static readonly MenuDecorations[] allValues = System.Enum.GetValues(typeof(MenuDecorations))
                .Cast<MenuDecorations>()
                .ToArray();


        public static string ToClass(this MenuDecorations decorations)
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

        private static string ValueToClass(this MenuDecorations value)
        {
            return value switch
            {
                None => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
