using System;
using System.Linq;

using static Proxoft.SemanticUI.Core.ImageDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum ImageDecorations
    {
        NoDecoration = 0,
        Avatar       = 1 << 0,
        Bordered     = 1 << 1,
        Centered     = 1 << 2,
        Circular     = 1 << 3,
        Disabled     = 1 << 4,
        Fluid        = 1 << 5,
        Hidden       = 1 << 6,
        Rounded      = 1 << 7,
    }

    public static class ImageDecorationsExtensions
    {
        private static readonly ImageDecorations[] _allValues = Enum.GetValues(typeof(ImageDecorations))
                .Cast<ImageDecorations>()
                .ToArray();

        public static string ToClass(this ImageDecorations decorations)
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

        private static string ValueToClass(this ImageDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }
}
