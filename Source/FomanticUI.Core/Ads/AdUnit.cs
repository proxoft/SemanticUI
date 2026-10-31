namespace Proxoft.FomanticUI.Core;

public enum AdUnit
{
    MediumRectangle,
    LargeRectangle,
    VerticalRectangle,
    SmallRectangle,
    HalfPage,
    Banner,
    VerticalBanner,
    TopBanner,
    HalfBanner,
    LargeMobileBanner,
    Button,
    SquareButton,
    SmallButton,
    Skyscraper,
    WideSkyscraper,
    Leaderboard,
    LargeLeaderboard,
    MobileLeaderboard,
    Billboard,
    Panorama,
    Netboard,
    Square,
    SmallSquare
}

public static class AdUnitExtensions
{
    // MediumRectangle => "medium rectangle"
    public static string ToClass(this AdUnit unit)
    {
        var name = unit.ToString();
        return string.Concat(name.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + c : c.ToString()))
            .ToLower();
    }
}