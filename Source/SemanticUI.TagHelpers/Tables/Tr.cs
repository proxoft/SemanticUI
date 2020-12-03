using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-tr")]
    public class Tr : TRowCell
    {
        public Tr() : base("tr")
        {
        }
    }
}
