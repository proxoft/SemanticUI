using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common
{
    [HtmlTargetElement("fui-description")]
    public class Description : FomanticTagHelper
    {
        public Description() : base("description", "div", false)
        {
        }

        protected override IEnumerable<string> Classes()
        {
            yield break;
        }
    }
}
