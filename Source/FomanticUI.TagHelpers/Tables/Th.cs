using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-th")]
public class Th : TCell
{
    public Th() : base("th")
    {
    }
}