using Microsoft.AspNetCore.Components;

namespace Proxoft.FomanticUI.Blazor;

public abstract class ContainerFomanticComponent : FomanticComponent
{
    protected ContainerFomanticComponent(string cssName, bool prefixUiClass = true) : base(cssName, prefixUiClass)
    {
    }

    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;
}