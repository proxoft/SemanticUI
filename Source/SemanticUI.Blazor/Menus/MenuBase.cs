using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public abstract class MenuBase : ContainerSemanticComponent
    {
        protected MenuBase(bool prefixUiClass) : base("menu", prefixUiClass)
        {
        }

        [Parameter]
        public Position Alignment { get; set; } = Position.Left;

        [Parameter]
        public Position Attached { get; set; }

        [Parameter]
        public Amount Items { get; set; }

        [Parameter]
        public MenuDecorations Decorations { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decorations.ToClass();
            yield return this.Items.ToClass("item");
            yield return this.Alignment.ToAlignmentClass();
            yield return this.Attached.ToAttachedClass();
        }
    }
}
