using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.CardDecorations;

namespace Proxoft.SemanticUI.Core
{

    [Flags]
    public enum CardDecorations
    {
        NoDecoration = 0,
        Centered,
        Fluid,
        Raised,
    }

    public static class CardsDecorationsExtensions
    {
        private static readonly CardDecorations[] allValues = Enum.GetValues(typeof(CardDecorations))
                .Cast<CardDecorations>()
                .ToArray();

        public static string ToClass(this CardDecorations decorations)
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

        private static string ValueToClass(this CardDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
