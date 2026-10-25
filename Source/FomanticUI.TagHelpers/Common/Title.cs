using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common
{
    [HtmlTargetElement("fui-title")]
    public class Title : FomanticTagHelper
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
