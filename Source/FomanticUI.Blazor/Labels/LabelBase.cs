using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public class LabelBase : ContainerFomanticComponent
{
    public LabelBase(string cssName = "label") : base(cssName)
    {
    }

    [Parameter]
    public Color Color { get; set; }

    [Parameter]
    public Size Size { get; set; }

    [Parameter]
    public LabelDecorations Decorations { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Color.ToClass();
        yield return Size.ToClass();
        yield return Decorations.ToClass();
    }
}