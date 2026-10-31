using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-linkButton")]
public class LinkButton : SingleButtonBase
{
    public LinkButton() : base("a")
    {
    }

    public string Href { get; set; } = "";

    public string? Target { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        output.Attributes.Add("href", Href);
        if (!string.IsNullOrWhiteSpace(Target)) output.Attributes.Add("target", Target);
    }
}