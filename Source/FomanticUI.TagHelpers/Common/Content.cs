using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Common;

[HtmlTargetElement("fui-content")]
public class Content : FomanticTagHelper
{
    public Content() : base("content", "div", false)
    {
    }

    public bool Extra { get; set; }

    public Position VerticallyAligned { get; set; }

    public Position Floated { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return VerticallyAligned.ToVerticalAlignmentClass();
        yield return Floated.ToFloatedClass();
        yield return "extra".ToClassIf(Extra);
    }
}