namespace Proxoft.SemanticUI.Core
{
    public enum Color
    {
        NoColor,
        Red,
        Orange,
        Yellow,
        Olive,
        Green,
        Teal,
        Blue,
        Violet,
        Purple,
        Pink,
        Brown,
        Grey,
        Black
    }

    public static class ColorExtensions
    {
        public static string ToClass(this Color color)
        {
            return color == Color.NoColor
                ? string.Empty
                : color.ToString().ToLower();
        }
    }
}
