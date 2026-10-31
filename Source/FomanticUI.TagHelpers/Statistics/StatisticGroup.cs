using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Statistics;

[HtmlTargetElement("fui-statistic-group")]
public class StatisticGroup : FomanticTagHelper
{
    public StatisticGroup() : base("statistics", "div")
    {
    }

    public Amount Amount { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Amount.ToClass(string.Empty);
    }
}