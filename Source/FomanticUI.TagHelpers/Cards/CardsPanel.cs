using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Cards;

[HtmlTargetElement("fui-cards-panel")]
public class CardsPanel : FomanticTagHelper
{
    public CardsPanel() : base("cards", "div")
    {
    }

    public Amount Count { get; set; }

    public bool Stackable { get; set; }

    public bool Doubling { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return Count.ToClass(string.Empty);
        yield return "stackable".ToClassIf(Stackable);
        yield return "doubling".ToClassIf(Doubling);
    }
}