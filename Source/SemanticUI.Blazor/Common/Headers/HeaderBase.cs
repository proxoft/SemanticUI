using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public class HeaderBase : SemanticComponent
    {
        public HeaderBase(string cssName, bool prefixUiClass) : base(cssName, prefixUiClass)
        {
        }

        [Parameter]
        public HeaderDecorations Decorations { get; set; }

        [Parameter]
        public Size Size { get; set; }

        [Parameter]
        public Color Color { get; set; }

        [Parameter]
        public Position Alignment { get; set; }

        [Parameter]
        public Position Attached { get; set; }

        [Parameter]
        public Position Floated { get; set; }

        protected override IEnumerable<string> Classes()
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
