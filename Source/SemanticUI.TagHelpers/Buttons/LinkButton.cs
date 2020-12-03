using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-linkButton")]
    public class LinkButton : SingleButtonBase
    {
        public LinkButton() : base("a")
        {
        }

        public string Href { get; set; }

        public string Target { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.Add("href", this.Href);
            if (!string.IsNullOrWhiteSpace(this.Target))
            {
                output.Attributes.Add("target", this.Target);
            }
        }
    }
}
