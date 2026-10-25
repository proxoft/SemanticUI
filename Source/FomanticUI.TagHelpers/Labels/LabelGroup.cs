using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-labelGroup")]
    public class LabelGroup : FomanticTagHelper
    {
        public LabelGroup() : base("labels", "div")
        {
        }

        public Color Color { get; set; }

        public Size Size { get; set; }

        // only circular and tag
        public LabelDecorations Decorations { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return this.Size.ToClass();
            yield return this.Decorations.ToClass();
        }
    }
}
