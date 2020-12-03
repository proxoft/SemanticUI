using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-column")]
    public class Column : SemanticTagHelper
    {
        public Column() : base("column", "div", false)
        {
        }

        public Position Aligned { get; set; }

        public Amount Wide { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Wide.ToClass("wide");
            yield return this.Aligned.ToAlignmentClass();
        }
    }
}
