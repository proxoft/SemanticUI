using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Common.Headers
{
    [HtmlTargetElement("sui-header")]
    public class Header : HeaderBase
    {
        public Header() : base("header", true)
        {
        }
    }
}
