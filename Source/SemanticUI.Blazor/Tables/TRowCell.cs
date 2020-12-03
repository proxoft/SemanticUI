using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public abstract class TRowCell : ContainerSemanticComponent
    {
        protected TRowCell() : base(string.Empty, false)
        {
        }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public Severity Severity { get; set; }

        [Parameter]
        public State State { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.State.ToClass();
            yield return this.Severity.ToClass();
            yield return "disabled".ToClassIf(this.Disabled);
            yield return "active".ToClassIf(this.Active);
        }
    }
}
