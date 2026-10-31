using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

public abstract class FomanticTagHelper : TagHelper
{
    protected FomanticTagHelper(
        string cssName,
        string tagName,
        bool prefixUi = true)
    {
        CssName = cssName;
        TagName = tagName;
        PrefixUi = prefixUi;
    }

    protected string TagName { get; }

    protected string CssName { get; }

    protected bool PrefixUi { get; set; }

    protected TagMode TagMode { get; set; } = TagMode.StartTagAndEndTag;

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        base.Process(context, output);

        output.TagName = TagName;
        output.TagMode = TagMode;

        output.Attributes.SetAttribute("class", Class());
    }

    protected string Class()
    {
        return new[]
            {
                "ui".ToClassIf(PrefixUi)
            }
            .Concat(Classes())
            .Concat(new[] { CssName })
            .Concat(AfterCssNameClasses())
            .ToClass();
    }

    /// <summary>
    ///     true when the attribute bound to the property was written on the element,
    ///     e.g. IsSet(context, nameof(IconName)) checks for icon-name="...".
    /// </summary>
    protected static bool IsSet(TagHelperContext context, string propertyName)
    {
        return context.AllAttributes.ContainsName(ToHtmlName(propertyName));
    }

    // the same property-to-attribute naming Razor uses for tag helpers (IconName -> icon-name)
    private static string ToHtmlName(string propertyName)
    {
        return Regex.Replace(propertyName, "(?<!^)((?<=[a-zA-Z0-9])[A-Z][a-z])|((?<=[a-z])[A-Z])", "-$1$2")
            .ToLowerInvariant();
    }

    protected abstract IEnumerable<string> Classes();

    protected virtual IEnumerable<string> AfterCssNameClasses()
    {
        yield break;
    }
}