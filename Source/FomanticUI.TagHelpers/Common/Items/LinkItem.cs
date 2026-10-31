using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Common.Items;

[HtmlTargetElement("fui-link-item")]
public class LinkItem : AnchorTagHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LinkItem(IHttpContextAccessor httpContextAccessor, IHtmlGenerator generator) : base(generator)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Color Color { get; set; }

    public bool IsActive { get; set; }

    public bool IsHeader { get; set; }

    public string? RightIcon { get; set; }

    public ActiveUrlMatch ActiveUrlMatch { get; set; } = ActiveUrlMatch.Exact;

    protected bool HasRightIcon => !string.IsNullOrWhiteSpace(RightIcon);

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);
        output.TagName = "a";
        output.TagMode = TagMode.StartTagAndEndTag;

        output.Attributes.Add("class", CreateClasses().ToClass());

        if (!string.IsNullOrWhiteSpace(RightIcon))
        {
            var iconClass = $"ui {RightIcon} icon";
            output.PostContent.SetHtmlContent($"<i class=\"{iconClass}\"></i>");
        }
    }

    private IEnumerable<string> CreateClasses()
    {
        yield return "header".ToClassIf(IsHeader);
        yield return "active".ToClassIf(IsActiveClass());
        yield return Color.ToClass();
        yield return "item";
    }

    private bool IsActiveClass()
    {
        if (IsActive) return true;

        if (ActiveUrlMatch == ActiveUrlMatch.None || string.IsNullOrWhiteSpace(Page)) return false;

        HttpRequest? request = _httpContextAccessor.HttpContext?.Request;
        if (request is null) return false;

        var path = request.Path.ToString();
        if (ActiveUrlMatch == ActiveUrlMatch.Exact) path += "/Index";

        return path.Contains(Page, StringComparison.CurrentCultureIgnoreCase);
    }
}