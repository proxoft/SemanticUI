using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Common
{
    [HtmlTargetElement("sui-content")]
    public class Content : SemanticTagHelper
    {
        public Content() : base("content", "div", false)
        {
        }

        public bool Extra { get; set; }

        public Position VerticallyAligned { get; set; }

        public Position Floated { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.VerticallyAligned.ToVerticalAlignmentClass();
            yield return this.Floated.ToFloatedClass();
            yield return "extra".ToClassIf(this.Extra);
        }
    }
}
