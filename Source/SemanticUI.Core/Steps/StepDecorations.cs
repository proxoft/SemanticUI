using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.StepDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum StepDecorations
    {
        NoDecoration = 0,
        Link         = 1 << 0,
        Disabled     = 1 << 1,
        Active       = 1 << 2,
        Completed    = 1 << 3
    }

    public static class StepDecorationsExtensions
    {
        private static readonly StepDecorations[] allValues = Enum.GetValues(typeof(StepDecorations))
                .Cast<StepDecorations>()
                .ToArray();

        public static string ToClass(this StepDecorations decorations)
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

        private static string ValueToClass(this StepDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
