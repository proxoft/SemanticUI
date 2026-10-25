using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-submenu")]
    public class SubMenu : MenuBase
    {
        public SubMenu() : base(false)
        {
        }
    }
}
