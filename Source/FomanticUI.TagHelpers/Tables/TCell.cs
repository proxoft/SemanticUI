using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

public abstract class TCell : TRowCell
{
    public TCell(string tagName) : base(tagName)
    {
    }

    public Position Alignment { get; set; } = Position.Default;

    public bool Collapsing { get; set; }

    public int RowSpan { get; set; }

    public int ColSpan { get; set; }

    public Amount Wide { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
        if (ColSpan > 1) output.Attributes.SetAttribute("colspan", ColSpan);

        if (RowSpan > 1) output.Attributes.SetAttribute("rowspan", ColSpan);
    }

    protected override IEnumerable<string> Classes()
    {
        return base.Classes()
            .Concat(ClassesPrivate());
    }

    private IEnumerable<string> ClassesPrivate()
    {
        yield return "collapsing".ToClassIf(Collapsing);
        yield return Alignment.ToAlignmentClass();
        yield return Wide.ToClass("wide");
    }
}