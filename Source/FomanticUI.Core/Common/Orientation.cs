namespace Proxoft.FomanticUI.Core;

public enum Orientation
{
    Horizontal,
    Vertical
}

public static class OrientationExtensions
{
    public static string ToClass(this Orientation orientation, Orientation emptyIf = Orientation.Horizontal)
    {
        return orientation == emptyIf
            ? string.Empty
            : orientation.ToString().ToLower();
    }
}