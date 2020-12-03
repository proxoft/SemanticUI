using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-buttonsGroup")]
    public class ButtonsGroup : ButtonBase<ButtonsGroupData>
    {
        public ButtonsGroup() : base("buttons", "div")
        {
        }

        public Orientation Orientation
        {
            get => this.Data.Orientation;
            set => this.Data.Orientation = value;
        }

        public Amount Amount
        {
            get => this.Data.Amount;
            set => this.Data.Amount = value;
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Orientation.ToClass(emptyIf: Orientation.Horizontal),
                    this.Amount.ToClass(string.Empty)
                });
        }
    }
}
