using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-row")]
public class Row : FomanticTagHelper
{
    public Row() : base("row", "div", false)
    {
    }

    public Amount Columns { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Columns.ToClass("column");
    }
}