using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-field")]
    public class Field : SemanticTagHelper
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
            yield return this.State.ToClass();
            yield return this.Wide.ToClass("wide");
            yield return "required".ToClassIf(this.Required);
            yield return "error".ToClassIf(this.HasError);
        }
    }
}
