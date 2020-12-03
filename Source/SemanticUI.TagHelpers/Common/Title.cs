using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Common
{
    [HtmlTargetElement("sui-title")]
    public class Title : SemanticTagHelper
    {
        public Title() : base("title", "div", false)
        {
        }

        protected override IEnumerable<string> Classes()
        {
            yield break;
        }
    }
}
