using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Common.Items;

[HtmlTargetElement("fui-item")]
public class Item : FomanticTagHelper
{
    public Item() : base("item", "div", false)
    {
    }

    public Color Color { get; set; }

    public bool IsHeader { get; set; }

    public bool IsActive { get; set; }

    public string? RightIcon { get; set; }

    protected bool HasRightIcon => !string.IsNullOrWhiteSpace(RightIcon);

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        if (!string.IsNullOrWhiteSpace(RightIcon))
        {
            var iconClass = $"ui {RightIcon} icon";
            output.PostContent.SetHtmlContent($"<i class=\"{iconClass}\"></i>");
        }
    }

    protected sealed override IEnumerable<string> Classes()
    {
        yield return Color.ToClass();
        yield return "header".ToClassIf(IsHeader);
        yield return "active".ToClassIf(IsActive);
    }
}