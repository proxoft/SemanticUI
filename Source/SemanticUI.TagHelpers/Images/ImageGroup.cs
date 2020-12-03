using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Images
{
    [HtmlTargetElement("sui-image-group")]
    public class ImageGroup : SemanticTagHelper
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
