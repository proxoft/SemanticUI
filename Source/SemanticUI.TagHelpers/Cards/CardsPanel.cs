using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Cards
{
    [HtmlTargetElement("sui-cards-panel")]
    public class CardsPanel : SemanticTagHelper
    {
        public CardsPanel() : base("cards", "div")
        {
        }

        public Amount Count { get; set; }

        public bool Stackable { get; set; }

        public bool Doubling { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Count.ToClass(of: string.Empty);
            yield return "stackable".ToClassIf(this.Stackable);
            yield return "doubling".ToClassIf(this.Doubling);
        }
    }
}
