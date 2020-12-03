namespace Proxoft.SemanticUI.Core
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
                LabelPointing.LeftPointing => "left poingin",
                LabelPointing.RightPointing => "right pointing",
                LabelPointing.BellowPointing => "pointing bellow",
                _ => string.Empty
            };
        }
    }
}
