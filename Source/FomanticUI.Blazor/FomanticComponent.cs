using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.Blazor;

public abstract class FomanticComponent : ComponentBase
{
    private Tooltip _tooltip = new ();

    protected FomanticComponent(string cssName, bool prefixUiClass = true)
    {
        this.CssName = cssName;
        this.PrefixUiClass = prefixUiClass;
    }

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> UnmatchedAttributes { get; set; } = [];

    [Parameter]
    public Tooltip? Tooltip
    {
        get => _tooltip;
        set => _tooltip = value ?? new Tooltip();
    }

    [Parameter]
    public string TooltipContent
    {
        get => this.Tooltip?.Content ?? "";
        set => this.Tooltip?.Content = value;
    }

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
            this.PrefixUiClass.ToClassIf("ui")
        }
        .Concat(this.Classes())
        .Concat([this.CssName])
        .Concat(this.AfterCssNameClasses())
        .Concat([this.CssClass])
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
        var attributes = new Dictionary<string, object>(this.UnmatchedAttributes ?? []);
        this.InitializeAttributes(attributes);
        return attributes;
    }

    protected virtual void InitializeAttributes(Dictionary<string, object> attributes)
    {
        this.Tooltip?.SetAttributes(attributes);
        this.Title.SetAsAttribute("title", attributes);
    }
}
