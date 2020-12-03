using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-segment")]
    public class Segment : SemanticTagHelper
    {
        public Segment() : base("segment", "div")
        {
        }

        public Color Color { get; set; }

        public SegmentDecorations Decorations { get; set; }

        public Position Alignment { get; set; }

        public Position Attached { get; set; }

        public Position Floated { get; set; }

        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decorations.ToClass();
            yield return this.Color.ToClass();
            yield return this.Alignment.ToAlignmentClass();
            yield return this.Floated.ToFloatedClass();
            yield return this.Attached.ToAttachedClass();
            yield return this.Orientation.ToClass(emptyIf: Orientation.Horizontal);
        }
    }
}
