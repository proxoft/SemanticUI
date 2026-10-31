using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common.Headers;

[HtmlTargetElement("fui-subheader")]
public class Subheader : HeaderBase
{
    public Subheader() : base("sub header", false)
    {
    }

    public bool IsRoot
    {
        get => PrefixUi;
        set => PrefixUi = value;
    }
}