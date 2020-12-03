using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Segments
{
    [HtmlTargetElement("sui-segmentGroup")]
    public class SegmentGroup : SemanticTagHelper
    {
        public SegmentGroup() : base("segments", "div")
        {
        }

        public bool Inverted { get; set; }

        public bool Stacked { get; set; }

        public bool Raised { get; set; }

        public bool Piled { get; set; }

        public Orientation Orientation { get; set; } = Orientation.Vertical;

        protected override IEnumerable<string> Classes()
        {
            yield return "inverted".ToClassIf(this.Inverted);
            yield return "piled".ToClassIf(this.Piled);
            yield return "stacked".ToClassIf(this.Stacked);
            yield return "raised".ToClassIf(this.Raised);
            yield return this.Orientation.ToClass(emptyIf: Orientation.Vertical);
        }
    }
}
