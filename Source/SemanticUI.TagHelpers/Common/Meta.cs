using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Common
{
    [HtmlTargetElement("sui-meta")]
    public class Meta : SemanticTagHelper
    {
        public Meta() : base("meta", "div", false)
        {
        }

        protected override IEnumerable<string> Classes()
        {
            yield break;
        }
    }
}
