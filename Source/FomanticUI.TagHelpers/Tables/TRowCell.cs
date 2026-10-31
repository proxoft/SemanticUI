using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers;

public abstract class TRowCell : FomanticTagHelper
{
    public TRowCell(string tagName) : base(string.Empty, tagName, false)
    {
    }

    public bool Disabled { get; set; }

    public bool Active { get; set; }

    public Severity Severity { get; set; }

    public State State { get; set; }

    protected override IEnumerable<string> Classes()
    {
        yield return State.ToClass();
        yield return Severity.ToClass();
        yield return "disabled".ToClassIf(Disabled);
        yield return "active".ToClassIf(Active);
    }
}