using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Icons;

[HtmlTargetElement("fui-icons")]
public class IconsGroup : FomanticTagHelper
{
    public IconsGroup() : base("icons", "i")
    {
    }

    public Size Size { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Size.ToClass();
    }
}