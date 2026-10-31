using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public class SingleButtonBase : ButtonBase<SingleButtonData>
{
    protected SingleButtonBase() : base("button")
    {
    }

    [Parameter]
    public ButtonState? State { get; set; }

    [Parameter]
    public Emphasizes? Emphasizes { get; set; }

    public bool Disabled => Effective.State != ButtonState.Enabled && Effective.State != ButtonState.Active;

    protected override SingleButtonData ApplyParameters(SingleButtonData data)
    {
        SingleButtonData applied = base.ApplyParameters(data);
        return applied with
        {
            State = State ?? applied.State,
            Emphasizes = Emphasizes ?? applied.Emphasizes
        };
    }

    protected override IEnumerable<string> Classes()
    {
        return base.Classes()
            .Concat(new[]
            {
                Effective.State.ToClass(),
                Effective.Emphasizes.ToClass()
            });
    }
}