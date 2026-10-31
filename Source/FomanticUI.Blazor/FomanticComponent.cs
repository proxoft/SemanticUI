using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public abstract class FomanticComponent : ComponentBase
{
    protected FomanticComponent(string cssName, bool prefixUiClass = true)
    {
        CssName = cssName;
        PrefixUiClass = prefixUiClass;
    }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> UnmatchedAttributes { get; set; } = [];

    [Parameter]
    public Tooltip? Tooltip { get; set; }

    /// <summary>
    ///     Tooltip text; overrides <see cref="Tooltip" />.Content.
    /// </summary>
    [Parameter]
    public string? TooltipContent { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter]
    public string CssClass { get; set; } = "";

    protected string CssName { get; set; } = "";

    protected bool PrefixUiClass { get; set; }

    internal string Class()
    {
        return new[]
            {
                PrefixUiClass.ToClassIf("ui")
            }
            .Concat(Classes())
            .Concat([CssName])
            .Concat(AfterCssNameClasses())
            .Concat([CssClass])
            .ToClass();
    }

    protected abstract IEnumerable<string> Classes();

    protected virtual IEnumerable<string> AfterCssNameClasses()
    {
        yield break;
    }

    internal Dictionary<string, object> Attributes()
    {
        // copy, so values added here never persist in UnmatchedAttributes across renders
        var attributes = new Dictionary<string, object>(UnmatchedAttributes ?? []);
        InitializeAttributes(attributes);
        return attributes;
    }

    protected virtual void InitializeAttributes(Dictionary<string, object> attributes)
    {
        Tooltip? tooltip = TooltipContent is { } content
            ? (Tooltip ?? new Tooltip()) with { Content = content }
            : Tooltip;

        tooltip.SetAttributes(attributes);
        Title.SetAsAttribute("title", attributes);
    }
}