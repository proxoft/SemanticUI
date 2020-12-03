using static Proxoft.SemanticUI.Core.LabelDecorations;

namespace Proxoft.SemanticUI.Core
{
    [System.Flags]
    public enum LabelDecorations
    {
        NoDecoration  = 0,
        Basic         = 1 << 0,
        Floating      = 1 << 1,
        Horizontal    = 1 << 2,
        Circular      = 1 << 3,
        CircularEmpty = 1 << 4,
        Image         = 1 << 5,
        Tag           = 1 << 6
    }

    public static class LabelDecorationsExtensions
    {
        public static string ToClass(this LabelDecorations decorations)
        {
            var classes = new string[]
            {
                decorations.TagClass(),
                decorations.CircularClass(),
                "basic".ToClassIf(decorations.HasFlag(Basic)),
                "image".ToClassIf(decorations.HasFlag(Image)),
                "floating".ToClassIf(decorations.HasFlag(Floating)),
                "horizontal".ToClassIf(decorations.HasFlag(Horizontal))
            };

            return classes.ToClass();
        }

        private static string TagClass(this LabelDecorations decorations)
        {
            return "tag".ToClassIf(decorations.HasFlag(Tag));
        }

        private static string CircularClass(this LabelDecorations decorations)
        {
            if (decorations.HasFlag(Tag))
            {
                return string.Empty;
            }

            if(decorations.HasFlag(CircularEmpty))
            {
                return "circular empty";
            }

            return "circular".ToClassIf(decorations.HasFlag(Circular));
        }
    }
}
