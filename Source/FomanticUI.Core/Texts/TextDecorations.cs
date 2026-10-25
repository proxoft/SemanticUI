using System;
using System.Linq;

using static Proxoft.FomanticUI.Core.TextDecorations;

namespace Proxoft.FomanticUI.Core
{
    [Flags]
    public enum TextDecorations
    {
        NoDecoration = 0,
        Inverted     = 1 << 0,
        Disabled     = 1 << 1,
        Primary      = 1 << 2,
        Secondary    = 1 << 3
    }

    public static class TextDecorationsExtensions
    {
        private static readonly TextDecorations[] _allValues = Enum.GetValues(typeof(TextDecorations))
                .Cast<TextDecorations>()
                .ToArray();

        public static string ToClass(this TextDecorations decorations)
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

        private static string ValueToClass(this TextDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
