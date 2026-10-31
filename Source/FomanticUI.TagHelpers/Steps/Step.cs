using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Steps;

[HtmlTargetElement("fui-step")]
public class Step : FomanticTagHelper
{
    public Step() : base("step", "div", false)
    {
    }

    public StepDecorations Decorations { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
    }
}