using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Statistics;

[HtmlTargetElement("fui-statistic-label")]
public class Label : FomanticTagHelper
{
    public Label() : base("label", "div", false)
    {
    }

    protected override IEnumerable<string> Classes()
    {
        yield break;
    }
}