using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Images;

[HtmlTargetElement("fui-image")]
public class Image : FomanticTagHelper
{
    public Image() : base("image", "img")
    {
    }

    public string Src { get; set; } = "";

    public string? Alt { get; set; }

    public ImageDecorations Decorations { get; set; }

    public Size Size { get; set; }

    public Position VerticallyAligned { get; set; }

    public Position Spaced { get; set; }

    public Position Floated { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        output.Attributes.SetAttribute("src", Src ?? string.Empty);
        if (!string.IsNullOrWhiteSpace(Alt)) output.Attributes.SetAttribute("alt", Alt);
    }

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
        yield return Size.ToClass();
        yield return VerticallyAligned.ToVerticalAlignmentClass();
        yield return Spaced.ToSpacedClass();
        yield return Floated.ToFloatedClass();
    }
}