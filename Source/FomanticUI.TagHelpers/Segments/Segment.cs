using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-segment")]
public class Segment : FomanticTagHelper
{
    public Segment() : base("segment", "div")
    {
    }

    public Color Color { get; set; }

    public SegmentDecorations Decorations { get; set; }

    public Position Alignment { get; set; }

    public Position Attached { get; set; }

    public Position Floated { get; set; }

    public Orientation Orientation { get; set; } = Orientation.Horizontal;

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
        yield return Color.ToClass();
        yield return Alignment.ToAlignmentClass();
        yield return Floated.ToFloatedClass();
        yield return Attached.ToAttachedClass();
        yield return Orientation.ToClass(Orientation.Horizontal);
    }
}