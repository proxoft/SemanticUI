using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-column")]
public class Column : FomanticTagHelper
{
    public Column() : base("column", "div", false)
    {
    }

    public Position Aligned { get; set; }

    public Amount Wide { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Wide.ToClass("wide");
        yield return Aligned.ToAlignmentClass();
    }
}