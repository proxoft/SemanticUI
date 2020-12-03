using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Sample.TagHelpers
{
    [HtmlTargetElement("sl-description")]
    public class DescriptionTagHelper : TagHelper
    {
        public string Header { get; set; }
        public string Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.PreContent.SetHtmlContent($"<h4>{Header}</h4><p>{Text}</p>");
        }
    }
}
