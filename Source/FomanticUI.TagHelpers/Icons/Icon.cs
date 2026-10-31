using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-icon")]
public class Icon : FomanticTagHelper
{
    private IconData _effective = new();

    public Icon() : base("icon", "i", false)
    {
    }

    /// <summary>
    ///     All settings in one value; attributes written on the element override its values.
    /// </summary>
    public IconData? Data { get; set; }

    public string Name { get; set; } = "";

    public Size Size { get; set; }

    public Color Color { get; set; }

    public IconDecorations Decorations { get; set; }

    public Position Corner { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        IconData data = Data ?? new IconData();
        _effective = data with
        {
            Name = IsSet(context, nameof(Name)) ? Name : data.Name,
            Size = IsSet(context, nameof(Size)) ? Size : data.Size,
            Color = IsSet(context, nameof(Color)) ? Color : data.Color,
            Decorations = IsSet(context, nameof(Decorations)) ? Decorations : data.Decorations,
            Corner = IsSet(context, nameof(Corner)) ? Corner : data.Corner
        };

        base.Process(context, output);
    }

    protected override IEnumerable<string> Classes()
    {
        yield return _effective.ToClass();
    }
}