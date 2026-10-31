using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-form")]
public class Form : FomanticTagHelper
{
    public Form() : base("form", "div")
    {
    }

    public Size Size { get; set; }

    public Severity Severity { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Size.ToClass();
        yield return Severity.ToClass();
    }
}