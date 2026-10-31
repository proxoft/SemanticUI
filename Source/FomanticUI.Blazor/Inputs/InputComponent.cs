using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public class InputComponent : FomanticComponent
{
    public InputComponent(string cssName, bool prefixUiClass = true) : base(cssName, prefixUiClass)
    {
    }

    [Parameter]
    public Size Size { get; set; }

    [Parameter]
    public EditState State { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Size.ToClass();
        yield return State.ToClass();
    }
}