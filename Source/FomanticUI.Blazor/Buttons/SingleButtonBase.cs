using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor
{
    public class SingleButtonBase : ButtonBase<SingleButtonData>
    {
        protected SingleButtonBase(): base("button")
        {
        }

        [Parameter]
        public ButtonState? State { get; set; }

        [Parameter]
        public Emphasizes? Emphasizes { get; set; }

        public bool Disabled => this.Effective.State != ButtonState.Enabled && this.Effective.State != ButtonState.Active;

        protected override SingleButtonData ApplyParameters(SingleButtonData data)
        {
            var applied = base.ApplyParameters(data);
            return applied with
            {
                State = this.State ?? applied.State,
                Emphasizes = this.Emphasizes ?? applied.Emphasizes
            };
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Effective.State.ToClass(),
                    this.Effective.Emphasizes.ToClass()
                });
        }
    }
}
