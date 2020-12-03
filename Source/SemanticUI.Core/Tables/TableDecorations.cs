using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.TableDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum TableDecorations
    {
        DefaultProperties = 0,
        Basic             = 1 << 0,
        VeryBasic         = 1 << 1,  // use either Basic or VeryBasic
        Celled            = 1 << 2,
        Collapsing        = 1 << 3,
        Compact           = 1 << 4,
        Definition        = 1 << 5,
        Fixed             = 1 << 6,
        Inverted          = 1 << 7,
        Padded            = 1 << 8,
        VeryPadded        = 1 << 9, // use either Padded or VeryPadded
        SingleLine        = 1 << 10,
        SelectableRow     = 1 << 11,
        Striped           = 1 << 12,
        Structured        = 1 << 13
    }

    public static class TableParametersExtensions
    {
        private static readonly TableDecorations[] allValues = Enum.GetValues(typeof(TableDecorations))
                .Cast<TableDecorations>()
                .ToArray();

        public static string ToClass(this TableDecorations decorations)
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

        private static string ValueToClass(this TableDecorations value)
        {
            return value switch
            {
                DefaultProperties => string.Empty,
                VeryBasic => "very basic",
                VeryPadded => "very padded",
                SingleLine => "single line",
                SelectableRow => "selectable",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
