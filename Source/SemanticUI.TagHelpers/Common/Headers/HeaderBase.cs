using System;
using System.Collections.Generic;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Common.Headers
{
    public class HeaderBase : SemanticTagHelper
    {
        public HeaderBase(string cssName, bool prefixUi) : base(cssName, "div", prefixUi)
        {
        }

        public HeaderDecorations Decorations { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public Position Alignment { get; set; }

        public Position Attached { get; set; }

        public Position Floated { get; set; }

        protected override sealed IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return this.Decorations.ToClass();
            if (!this.Decorations.HasFlag(HeaderDecorations.Justified))
            {
                yield return this.Alignment.ToAlignmentClass();
            }
            yield return this.Size.ToClass();
            yield return this.Attached.ToAttachedClass();
            yield return this.Floated.ToFloatedClass();
        }
    }
}
