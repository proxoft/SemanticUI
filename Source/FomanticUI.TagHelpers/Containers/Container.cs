using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-container")]
public class Container : FomanticTagHelper
{
    public Container() : base("container", "div")
    {
    }

    public bool Fluid { get; set; }

    public Position Alignment { get; set; } = Position.Default;

    protected override IEnumerable<string> Classes()
    {
        yield return Alignment.ToAlignmentClass();
        yield return "fluid".ToClassIf(Fluid);
    }
}