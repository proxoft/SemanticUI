using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    public abstract class SingleButtonBase : ButtonBase<SingleButtonData>
    {
        protected SingleButtonBase(string tagName) : base("button", tagName)
        {
        }

        public ButtonState State
        {
            get => this.Data.State;
            set => this.Data.State = value;
        }

        public Emphasizes Emphasizes
        {
            get => this.Data.Emphasizes;
            set => this.Data.Emphasizes = value;
        }

        public bool Disabled => this.State == ButtonState.Disabled;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if (this.Disabled)
            {
                output.Attributes.Add("disabled", "disabled");
            }
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Emphasizes.ToClass(),
                    this.State.ToClass()
                });
        }
    }
}
