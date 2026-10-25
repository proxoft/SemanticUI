namespace Proxoft.FomanticUI.Core
{
    public enum LabelPointing
    {
        NoPointing,
        UpPointing,
        LeftPointing,
        RightPointing,
        BellowPointing
    }

    public static class PointingExtensions
    {
        public static string ToClass(this LabelPointing pointing)
        {
            return pointing switch
            {
                LabelPointing.UpPointing => "pointing",
                LabelPointing.LeftPointing => "left pointing",
                LabelPointing.RightPointing => "right pointing",
                LabelPointing.BellowPointing => "pointing below",
                _ => string.Empty
            };
        }
    }
}
