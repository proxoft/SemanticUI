using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-container")]
    public class Container : SemanticTagHelper
    {
        public Container() : base("container", "div")
        {
        }

        public bool Fluid { get; set; }

        public Position Alignment { get; set; } = Position.Default;

        protected override IEnumerable<string> Classes()
        {
            yield return this.Alignment.ToAlignmentClass();
            yield return "fluid".ToClassIf(this.Fluid);
        }
    }
}
