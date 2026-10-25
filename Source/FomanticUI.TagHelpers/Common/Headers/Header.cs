using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers.Common.Headers
{
    [HtmlTargetElement("fui-header")]
    public class Header : HeaderBase
    {
        public Header() : base("header", true)
        {
        }
    }
}
