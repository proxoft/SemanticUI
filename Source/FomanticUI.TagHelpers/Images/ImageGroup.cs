using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Images
{
    [HtmlTargetElement("fui-image-group")]
    public class ImageGroup : FomanticTagHelper
    {
        public ImageGroup() : base("images", "div")
        {
        }

        public Size Size { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Size.ToClass();
        }
    }
}
