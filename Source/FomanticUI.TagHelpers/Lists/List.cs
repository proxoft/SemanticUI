using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Lists;

[HtmlTargetElement("fui-list")]
public class List : FomanticTagHelper
{
    public List() : base("list", "div")
    {
    }

    public ListDecorations Decorations { get; set; }

    public Orientation Orientation { get; set; } = Orientation.Vertical;

    public Size Size { get; set; }

    public Position VerticallyAligned { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return VerticallyAligned.ToVerticalAlignmentClass();
        yield return Decorations.ToClass();
        yield return Orientation.ToClass(Orientation.Vertical);
        yield return Size.ToClass();
    }
}