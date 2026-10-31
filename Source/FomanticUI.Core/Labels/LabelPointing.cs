namespace Proxoft.FomanticUI.Core;

public enum LabelPointing
{
    No,
    Up,
    Left,
    Right,
    Below
}

public static class PointingExtensions
{
    public static string ToClass(this LabelPointing pointing)
    {
        return pointing switch
        {
            LabelPointing.Up => "pointing",
            LabelPointing.Left => "left pointing",
            LabelPointing.Right => "right pointing",
            LabelPointing.Below => "pointing below",
            _ => string.Empty
        };
    }
}