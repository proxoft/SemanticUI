using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-grid")]
public class Grid : FomanticTagHelper
{
    public Grid() : base("grid", "div")
    {
    }

    public Amount Columns { get; set; }

    public GridDecorations Decorations { get; set; }

    public bool IsContainer { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Decorations.ToClass();
        yield return Columns.ToClass("column");
    }

    protected override IEnumerable<string> AfterCssNameClasses()
    {
        return base.AfterCssNameClasses()
                .Concat(new[] { "container".ToClassIf(IsContainer) })
            ;
    }
}