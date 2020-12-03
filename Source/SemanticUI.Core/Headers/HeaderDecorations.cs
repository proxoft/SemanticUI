using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.HeaderDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum HeaderDecorations
    {
        NoDecoration = 0,
        Block        = 1 << 0,
        Disabled     = 1 << 1,
        Dividing     = 1 << 2,
        Icon         = 1 << 3,
        Inverted     = 1 << 4,
        Justified    = 1 << 5
    }

    public static class HeaderDecorationsExtensions
    {
        private static readonly HeaderDecorations[] allValues = Enum.GetValues(typeof(HeaderDecorations))
                .Cast<HeaderDecorations>()
                .ToArray();

        public static string ToClass(this HeaderDecorations decorations)
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

        private static string ValueToClass(this HeaderDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
