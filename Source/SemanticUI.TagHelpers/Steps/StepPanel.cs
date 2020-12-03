using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Steps
{
    [HtmlTargetElement("sui-step-panel")]
    public class StepPanel : SemanticTagHelper
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
            yield return this.Decorations.ToClass();
            yield return this.Attached.ToAttachedClass();
            yield return this.Size.ToClass();
            yield return this.Amount.ToClass(of: string.Empty);
        }
    }
}
