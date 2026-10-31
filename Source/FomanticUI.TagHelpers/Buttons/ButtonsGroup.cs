using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

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
        ButtonsGroupData applied = base.ApplyProperties(context, data);
        return applied with
        {
            Orientation = IsSet(context, nameof(Orientation)) ? Orientation : applied.Orientation,
            Amount = IsSet(context, nameof(Amount)) ? Amount : applied.Amount
        };
    }

    protected override IEnumerable<string> Classes()
    {
        return base.Classes()
            .Concat(new[]
            {
                Effective.Orientation.ToClass(),
                Effective.Amount.ToClass(string.Empty)
            });
    }
}