using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public abstract class MenuBase : ContainerFomanticComponent
{
    protected MenuBase(bool prefixUiClass) : base("menu", prefixUiClass)
    {
    }

    [Parameter]
    public Position Alignment { get; set; } = Position.Left;

    [Parameter]
    public Position Attached { get; set; }

    [Parameter]
    public Amount Items { get; set; }

    [Parameter]
    public MenuDecorations Decorations { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
        yield return Items.ToClass("item");
        yield return Alignment.ToAlignmentClass();
        yield return Attached.ToAttachedClass();
    }
}