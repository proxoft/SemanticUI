using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-field")]
public class Field : FomanticTagHelper
{
    public Field() : base("field", "div", false)
    {
    }

    public bool HasError { get; set; }

    public Amount Wide { get; set; }

    public bool Required { get; set; }

    public EditState State { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return State.ToClass();
        yield return Wide.ToClass("wide");
        yield return "required".ToClassIf(Required);
        yield return "error".ToClassIf(HasError);
    }
}