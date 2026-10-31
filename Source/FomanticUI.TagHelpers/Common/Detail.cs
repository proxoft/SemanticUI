using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common;

[HtmlTargetElement("fui-detail")]
public class Detail : FomanticTagHelper
{
    public Detail() : base("detail", "div", false)
    {
    }

    protected override IEnumerable<string> Classes()
    {
        yield break;
    }
}