using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.Blazor
{
    public class SingleButtonBase : ButtonBase<SingleButtonData>
    {
        protected SingleButtonBase(): base("button")
        {
        }

        [Parameter]
        public ButtonState State
        {
            get => this.Data.State;
            set => this.Data.State = value;
        }

        [Parameter]
        public Emphasizes Emphasizes
        {
            get => this.Data.Emphasizes;
            set => this.Data.Emphasizes = value;
        }

        public bool Disabled => this.State != ButtonState.Enabled && this.State != ButtonState.Active;

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.State.ToClass(),
                    this.Emphasizes.ToClass()
                });
        }
    }
}
