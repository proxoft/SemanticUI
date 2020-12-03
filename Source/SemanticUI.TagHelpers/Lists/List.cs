using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Lists
{
    [HtmlTargetElement("sui-list")]
    public class List : SemanticTagHelper
    {
        public List() : base("list", "div")
        {
        }

        public ListDecorations Decorations { get; set; }

        public Orientation Orientation { get; set; } = Orientation.Vertical;

        public Size Size { get; set; }

        public Position VerticallyAligned { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.VerticallyAligned.ToVerticalAlignmentClass();
            yield return this.Decorations.ToClass();
            yield return this.Orientation.ToClass(emptyIf: Orientation.Vertical);
            yield return this.Size.ToClass();
        }
    }
}
