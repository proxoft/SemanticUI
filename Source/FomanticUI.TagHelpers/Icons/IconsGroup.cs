using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Icons
{
    [HtmlTargetElement("fui-icons")]
    public class IconsGroup : FomanticTagHelper
    {
        public Size Size { get; set; }

        public IconsGroup() : base("icons", "i")
        {
        }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Size.ToClass();
        }
    }
}
