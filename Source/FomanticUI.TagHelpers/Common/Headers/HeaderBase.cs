using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Common.Headers;

public class HeaderBase : FomanticTagHelper
{
    public HeaderBase(string cssName, bool prefixUi) : base(cssName, "div", prefixUi)
    {
    }

    public HeaderDecorations Decorations { get; set; }

    public Size Size { get; set; }

    public Color Color { get; set; }

    public Position Alignment { get; set; }

    public Position Attached { get; set; }

    public Position Floated { get; set; }

    protected sealed override IEnumerable<string> Classes()
    {
        yield return Color.ToClass();
        yield return Decorations.ToClass();
        if (!Decorations.HasFlag(HeaderDecorations.Justified)) yield return Alignment.ToAlignmentClass();
        yield return Size.ToClass();
        yield return Attached.ToAttachedClass();
        yield return Floated.ToFloatedClass();
    }
}