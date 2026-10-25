using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Cards
{
    [HtmlTargetElement("fui-card")]
    public class Card : FomanticTagHelper
    {
        public Card() : base("card", "div")
        {
        }

        public Color Color { get; set; }

        public CardDecorations Decorations { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return this.Decorations.ToClass();
        }
    }
}
