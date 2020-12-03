using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-td")]
    public class Td : TCell
    {
        public Td() : base("td")
        {
        }
    }
}
