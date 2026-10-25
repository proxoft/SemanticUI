using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    public abstract class SingleButtonBase : ButtonBase<SingleButtonData>
    {
        protected SingleButtonBase(string tagName) : base("button", tagName)
        {
        }

        public ButtonState State { get; set; }

        public Emphasizes Emphasizes { get; set; }

        public bool Disabled => this.Effective.State == ButtonState.Disabled;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (this.Disabled)
            {
                output.Attributes.Add("disabled", "disabled");
            }
        }

        protected override SingleButtonData ApplyProperties(TagHelperContext context, SingleButtonData data)
        {
            var applied = base.ApplyProperties(context, data);
            return applied with
            {
                State = IsSet(context, nameof(this.State)) ? this.State : applied.State,
                Emphasizes = IsSet(context, nameof(this.Emphasizes)) ? this.Emphasizes : applied.Emphasizes
            };
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Effective.Emphasizes.ToClass(),
                    this.Effective.State.ToClass()
                });
        }
    }
}
