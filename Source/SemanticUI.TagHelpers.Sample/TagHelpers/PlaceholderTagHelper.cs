using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Sample.TagHelpers
{
    [HtmlTargetElement("sl-placeholder")]
    public class PlaceholderTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("style", "width:100%; height:50px; background: #a0b8c9;");
        }
    }
}
