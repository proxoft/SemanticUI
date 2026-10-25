namespace Proxoft.FomanticUI.Core
{
    public enum PlaceholderImageShape
    {
        Default,
        Square,
        Rectangular
    }

    public static class PlaceholderImageShapeExtensions
    {
        public static string ToClass(this PlaceholderImageShape shape)
        {
            return shape == PlaceholderImageShape.Default
                ? string.Empty
                : shape.ToString().ToLower();
        }
    }
}
