using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.LoaderDecorations;

namespace Proxoft.SemanticUI.Core
{
    public enum LoaderDecorations
    {
        NoDecoration  = 0,
        Centered      = 1 << 1,
        Indeterminate = 1 << 2,
        Inline        = 1 << 3,
        Text          = 1 << 4
    }

    public static class LoaderDecorationsExtensions
    {
        private static readonly LoaderDecorations[] allValues = Enum.GetValues(typeof(LoaderDecorations))
                .Cast<LoaderDecorations>()
                .ToArray();

        public static string ToClass(this LoaderDecorations decorations)
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

        private static string ValueToClass(this LoaderDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
