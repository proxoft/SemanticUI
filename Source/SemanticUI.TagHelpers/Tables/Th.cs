using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-th")]
    public class Th : TCell
    {
        public Th() : base("th")
        {
        }
    }
}
