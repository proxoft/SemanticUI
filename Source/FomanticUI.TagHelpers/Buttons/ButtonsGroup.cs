using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-buttonsGroup")]
    public class ButtonsGroup : ButtonBase<ButtonsGroupData>
    {
        public ButtonsGroup() : base("buttons", "div")
        {
        }

        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        public Amount Amount { get; set; }

        protected override ButtonsGroupData ApplyProperties(TagHelperContext context, ButtonsGroupData data)
        {
            var applied = base.ApplyProperties(context, data);
            return applied with
            {
                Orientation = IsSet(context, nameof(this.Orientation)) ? this.Orientation : applied.Orientation,
                Amount = IsSet(context, nameof(this.Amount)) ? this.Amount : applied.Amount
            };
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Effective.Orientation.ToClass(emptyIf: Orientation.Horizontal),
                    this.Effective.Amount.ToClass(string.Empty)
                });
        }
    }
}
