using System;
using System.Linq;
using static Proxoft.SemanticUI.Core.ItemDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum ItemDecorations
    {
        None     = 0,
        Disabled = 1 << 0,
        Fitted   = 1 << 1,
        Header   = 1 << 2
    }

    public static class ItemDecorationsExtensions
    {
        private static readonly ItemDecorations[] _allValues = Enum.GetValues(typeof(ItemDecorations))
                .Cast<ItemDecorations>()
                .ToArray();

        public static string ToClass(this ItemDecorations decorations)
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

        private static string ValueToClass(this ItemDecorations value)
        {
            return value switch
            {
                None => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
