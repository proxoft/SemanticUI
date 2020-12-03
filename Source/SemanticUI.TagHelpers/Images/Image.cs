using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Images
{
    [HtmlTargetElement("sui-image")]
    public class Image : SemanticTagHelper
    {
        public Image() : base("image", "img")
        {
        }

        public string Src { get; set; }
        public string Alt { get; set; }

        public ImageDecorations Decorations { get; set; }

        public Size Size { get; set; }

        public Position VerticallyAligned { get; set; }

        public Position Spaced { get; set; }

        public Position Floated { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.Attributes.SetAttribute("src", this.Src ?? string.Empty);
            if (!string.IsNullOrWhiteSpace(this.Alt))
            {
                output.Attributes.SetAttribute("alt", this.Alt);
            }
        }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decorations.ToClass();
            yield return this.Size.ToClass();
            yield return this.VerticallyAligned.ToVerticalAlignmentClass();
            yield return this.Spaced.ToSpacedClass();
            yield return this.Floated.ToFloatedClass();
        }
    }
}
