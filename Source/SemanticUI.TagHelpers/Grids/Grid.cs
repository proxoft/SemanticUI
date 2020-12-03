using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-grid")]
    public class Grid : SemanticTagHelper
    {
        public Grid() : base("grid", "div")
        {
        }

        public Amount Columns { get; set; }

        public GridDecorations Decorations { get; set; }

        public bool IsContainer { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Decorations.ToClass();
            yield return this.Columns.ToClass("column");
        }

        protected override IEnumerable<string> AfterCssNameClasses()
        {
            return base.AfterCssNameClasses()
                .Concat(new[] { "container".ToClassIf(this.IsContainer) })
                ;
        }
    }
}
