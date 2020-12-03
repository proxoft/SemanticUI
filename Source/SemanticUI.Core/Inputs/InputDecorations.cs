using System.Linq;

using static Proxoft.SemanticUI.Core.InputDecorations;

namespace Proxoft.SemanticUI.Core
{
    [System.Flags]
    public enum InputDecorations
    {
        NoDecoration = 0,
        Action       = 1 << 0,
        Icon         = 1 << 1,
        IconRight    = 1 << 2, // use either Icon or IconRight
        Inverted     = 1 << 3,
        Labeled      = 1 << 4,
        LabeledRight = 1 << 5, // use either Label or LabelRight
        Loading      = 1 << 6,
        Fluid        = 1 << 7,
        Focus        = 1 << 8,
        Transparent  = 1 << 9
    }

    public static class InputDecorationsExtensions
    {
        private static readonly InputDecorations[] _allValues = System.Enum.GetValues(typeof(InputDecorations))
                .Cast<InputDecorations>()
                .ToArray();

        public static string ToClass(this InputDecorations decorations)
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

        private static string ValueToClass(this InputDecorations value)
        {
            return value switch
            {
                NoDecoration => string.Empty,
                Icon when !value.HasFlag(IconRight) => "left icon",
                IconRight => "right icon",
                LabeledRight => "right labeled",
                Labeled when !value.HasFlag(LabeledRight) => "labeled",
                _ => value.ToString().ToLower(),
            };
        }
    }
}
