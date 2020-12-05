using System;
using System.Linq;
using static Proxoft.SemanticUI.Core.MenuDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum MenuDecorations
    {
        None       = 0,
        Borderless = 1 << 1,
        Compact    = 1 << 2,
        Icon       = 1 << 3,
        Inverted   = 1 << 4,
        Labeled    = 1 << 5,
        Left       = 1 << 6,
        Fixed      = 1 << 7,
        Fluid      = 1 << 8,
        Pagination = 1 << 9,
        Pointing   = 1 << 10,
        Secondary  = 1 << 11,
        Tabular    = 1 << 12,
        Text       = 1 << 13
    }

    public static class MenuDecorationsExtensions
    {
        private static readonly MenuDecorations[] _allValues = System.Enum.GetValues(typeof(MenuDecorations))
                .Cast<MenuDecorations>()
                .ToArray();


        public static string ToClass(this MenuDecorations decorations)
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
