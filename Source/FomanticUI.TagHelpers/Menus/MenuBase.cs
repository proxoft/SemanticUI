using System.Collections.Generic;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    public abstract class MenuBase : FomanticTagHelper
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
