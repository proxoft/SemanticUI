using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.StepPanelDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum StepPanelDecorations
    {
        NoDecoration = 0,
        Stackable    = 1 << 0,
        UnStackable  = 1 << 1,
        Fluid        = 1 << 2,
        Ordered      = 1 << 3,
        Vertical     = 1 << 4
    }

    public static class StepPanelDecorationsExtensions
    {
        private static readonly StepPanelDecorations[] allValues = Enum.GetValues(typeof(StepPanelDecorations))
                .Cast<StepPanelDecorations>()
                .ToArray();

        public static string ToClass(this StepPanelDecorations decorations)
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

        private static string ValueToClass(this StepPanelDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
