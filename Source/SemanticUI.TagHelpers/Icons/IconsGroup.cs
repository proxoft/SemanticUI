using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Icons
{
    [HtmlTargetElement("sui-icons")]
    public class IconsGroup : SemanticTagHelper
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
