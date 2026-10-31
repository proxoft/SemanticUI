using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Statistics;

[HtmlTargetElement("fui-statistic-value")]
public class Value : FomanticTagHelper
{
    public Value() : base("value", "div", false)
    {
    }

    public bool IsTextValue { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return "text".ToClassIf(IsTextValue);
    }
}