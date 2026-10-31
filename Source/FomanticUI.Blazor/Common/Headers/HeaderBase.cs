using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public class HeaderBase : ContainerFomanticComponent
{
    public HeaderBase(string cssName, bool prefixUiClass) : base(cssName, prefixUiClass)
    {
    }

    [Parameter]
    public HeaderDecorations Decorations { get; set; }

    [Parameter]
    public Size Size { get; set; }

    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public Position Alignment { get; set; }

    [Parameter]
    public Position Attached { get; set; }

    [Parameter]
    public Position Floated { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Color.ToClass();
        yield return Decorations.ToClass();
        if (!Decorations.HasFlag(HeaderDecorations.Justified)) yield return Alignment.ToAlignmentClass();
        yield return Size.ToClass();
        yield return Attached.ToAttachedClass();
        yield return Floated.ToFloatedClass();
    }
}