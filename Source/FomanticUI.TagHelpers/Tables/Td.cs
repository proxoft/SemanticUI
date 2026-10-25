using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-td")]
    public class Td : TCell
    {
        public Td() : base("td")
        {
        }
    }
}
