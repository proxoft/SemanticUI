using System.Collections.Generic;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    public abstract class MenuBase : SemanticTagHelper
    {
        protected MenuBase(bool prefixUi = true) : base("menu", "div", prefixUi)
        {
        }

        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        public Position Alignment { get; set; } = Position.Left;

        public MenuDecorations Decorations { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decorations.ToClass();
            yield return this.Orientation.ToClass();
            yield return this.Alignment.ToAlignmentClass();
        }
    }
}
