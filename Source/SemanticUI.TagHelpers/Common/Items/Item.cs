using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Common.Items
{
    [HtmlTargetElement("sui-item")]
    public class Item : SemanticTagHelper
    {
        public Item() : base("item", "div", false)
        {
        }

        public Color Color { get; set; }

        public bool IsHeader { get; set; }

        public bool IsActive { get; set; }

        public string RightIcon { get; set; }

        protected bool HasRightIcon => !string.IsNullOrWhiteSpace(this.RightIcon);

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (!string.IsNullOrWhiteSpace(this.RightIcon))
            {
                var iconClass = $"ui {this.RightIcon} icon";
                output.PostContent.SetHtmlContent($"<i class=\"{iconClass}\"></i>");
            }
        }

        protected sealed override IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return "header".ToClassIf(this.IsHeader);
            yield return "active".ToClassIf(this.IsActive);
        }
    }
}
