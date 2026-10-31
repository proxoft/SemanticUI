using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Statistics;

[HtmlTargetElement("fui-statistic")]
public class Statistic : FomanticTagHelper
{
    public Statistic() : base("statistic", "div")
    {
    }

    public Orientation Orientation { get; set; } = Orientation.Vertical;

    public Color Color { get; set; }

    public Size Size { get; set; }

    public Position Floated { get; set; }

    public bool Inverted { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Orientation.ToClass(Orientation.Vertical);
        yield return Color.ToClass();
        yield return Size.ToClass();
        yield return Floated.ToFloatedClass();
        yield return "inverted".ToClassIf(Inverted);
    }
}