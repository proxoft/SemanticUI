using Microsoft.AspNetCore.Components;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public class TCell : TRowCell
{
    [Parameter]
    public Position Alignment { get; set; } = Position.Default;

    [Parameter]
    public bool Collapsing { get; set; }

    [Parameter]
    public int RowSpan { get; set; }

    [Parameter]
    public int ColSpan { get; set; }

    [Parameter]
    public Amount Wide { get; set; }

    protected override IEnumerable<string> Classes()
    {
        return base.Classes()
            .Concat(ClassesPrivate());
    }

    protected override void InitializeAttributes(Dictionary<string, object> attributes)
    {
        if (RowSpan > 1) attributes["rowspan"] = RowSpan;

        if (ColSpan > 1) attributes["colspan"] = ColSpan;
    }

    private IEnumerable<string> ClassesPrivate()
    {
        yield return "collapsing".ToClassIf(Collapsing);
        yield return Alignment.ToAlignmentClass();
        yield return Wide.ToClass("wide");
    }
}