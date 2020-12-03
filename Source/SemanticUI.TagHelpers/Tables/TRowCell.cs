using System.Collections.Generic;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    public abstract class TRowCell : SemanticTagHelper
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
            yield return this.State.ToClass();
            yield return this.Severity.ToClass();
            yield return "disabled".ToClassIf(this.Disabled);
            yield return "active".ToClassIf(this.Active);
        }
    }
}
