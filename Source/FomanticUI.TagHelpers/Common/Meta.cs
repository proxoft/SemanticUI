using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common
{
    [HtmlTargetElement("fui-meta")]
    public class Meta : FomanticTagHelper
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
