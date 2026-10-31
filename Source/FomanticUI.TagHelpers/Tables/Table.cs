using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

[HtmlTargetElement("fui-table")]
public class Table : FomanticTagHelper
{
    public Table() : base("table", "table")
    {
    }

    public TableDecorations Decorations { get; set; } = TableDecorations.Compact | TableDecorations.Striped;

    public Size Size { get; set; }

    public Amount Columns { get; set; }

    public Color Color { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Size.ToClass();
        yield return Decorations.ToClass();
        yield return Columns.ToClass("column");
        yield return Color.ToClass();
    }
}