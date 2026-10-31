using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

public abstract class SingleButtonBase : ButtonBase<SingleButtonData>
{
    protected SingleButtonBase(string tagName) : base("button", tagName)
    {
    }

    public ButtonState State { get; set; }

    public Emphasizes Emphasizes { get; set; }

    public bool Disabled => Effective.State == ButtonState.Disabled;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
        if (Disabled) output.Attributes.Add("disabled", "disabled");
    }

    protected override SingleButtonData ApplyProperties(TagHelperContext context, SingleButtonData data)
    {
        SingleButtonData applied = base.ApplyProperties(context, data);
        return applied with
        {
            State = IsSet(context, nameof(State)) ? State : applied.State,
            Emphasizes = IsSet(context, nameof(Emphasizes)) ? Emphasizes : applied.Emphasizes
        };
    }

    protected override IEnumerable<string> Classes()
    {
        return base.Classes()
            .Concat(new[]
            {
                Effective.Emphasizes.ToClass(),
                Effective.State.ToClass()
            });
    }
}