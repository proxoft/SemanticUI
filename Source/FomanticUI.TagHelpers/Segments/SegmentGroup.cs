using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Segments;

[HtmlTargetElement("fui-segmentGroup")]
public class SegmentGroup : FomanticTagHelper
{
    public SegmentGroup() : base("segments", "div")
    {
    }

    public bool Inverted { get; set; }

    public bool Stacked { get; set; }

    public bool Raised { get; set; }

    public bool Piled { get; set; }

    public Orientation Orientation { get; set; } = Orientation.Vertical;

    protected override IEnumerable<string> Classes()
    {
        yield return "inverted".ToClassIf(Inverted);
        yield return "piled".ToClassIf(Piled);
        yield return "stacked".ToClassIf(Stacked);
        yield return "raised".ToClassIf(Raised);
        yield return Orientation.ToClass(Orientation.Vertical);
    }
}