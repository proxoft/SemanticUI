using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Steps;

[HtmlTargetElement("fui-step-panel")]
public class StepPanel : FomanticTagHelper
{
    public StepPanel() : base("steps", "div")
    {
    }

    public StepPanelDecorations Decorations { get; set; }

    public Position Attached { get; set; }

    public Size Size { get; set; }

    public Amount Amount { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
        yield return Attached.ToAttachedClass();
        yield return Size.ToClass();
        yield return Amount.ToClass(string.Empty);
    }
}