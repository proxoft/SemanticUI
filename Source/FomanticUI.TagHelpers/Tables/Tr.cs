using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-tr")]
public class Tr : TRowCell
{
    public Tr() : base("tr")
    {
    }
}