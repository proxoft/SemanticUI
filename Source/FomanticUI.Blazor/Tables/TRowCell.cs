using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public abstract class TRowCell : ContainerFomanticComponent
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
        yield return State.ToClass();
        yield return Severity.ToClass();
        yield return "disabled".ToClassIf(Disabled);
        yield return "active".ToClassIf(Active);
    }
}