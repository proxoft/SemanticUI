using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-button")]
    public class Button : SingleButtonBase
    {
        public Button() : base("button")
        {
        }
    }
}
