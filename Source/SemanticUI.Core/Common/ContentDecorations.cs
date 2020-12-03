using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.ContentDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum  ContentDecorations
    {
        NoDecoration = 0,
        Image        = 1 << 0,
        Scrolling    = 1 << 1,
        Extra        = 1 << 2
    }

    public static class ContentDecorationsExtensions
    {
        private static readonly ContentDecorations[] _allValues = Enum.GetValues(typeof(ContentDecorations))
                .Cast<ContentDecorations>()
                .ToArray();

        public static string ToClass(this ContentDecorations decorations)
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

        private static string ValueToClass(this ContentDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
