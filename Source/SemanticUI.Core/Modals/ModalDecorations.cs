using System;
using System.Linq;
using static Proxoft.SemanticUI.Core.ModalDecorations;

namespace Proxoft.SemanticUI.Core
{
    [Flags]
    public enum ModalDecorations
    {
        NoDecoration = 0,
        Basic        = 1 << 0,
        FullScreen   = 1 << 1,
        Scrolling    = 1 << 2
    }

    public static class ModalDecorationsExtensions
    {
        private static readonly ModalDecorations[] _allValues = Enum.GetValues(typeof(ModalDecorations))
                .Cast<ModalDecorations>()
                .ToArray();

        public static string ToClass(this ModalDecorations decorations)
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

        private static string ValueToClass(this ModalDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                _ => value.ToString().ToLower(),
            };
        }
    }

}
