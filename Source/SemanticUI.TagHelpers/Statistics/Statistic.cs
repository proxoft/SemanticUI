using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Statistics
{
    [HtmlTargetElement("sui-statistic")]
    public class Statistic : SemanticTagHelper
    {
        public Statistic() : base("statistic", "div")
        {
        }

        public Orientation Orientation { get; set; } = Orientation.Vertical;

        public Color Color { get; set; }

        public Size Size { get; set; }

        public Position Floated { get; set; }

        public bool Inverted { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Orientation.ToClass(Orientation.Vertical);
            yield return this.Color.ToClass();
            yield return this.Size.ToClass();
            yield return this.Floated.ToFloatedClass();
            yield return "inverted".ToClassIf(this.Inverted);
        }
    }
}
