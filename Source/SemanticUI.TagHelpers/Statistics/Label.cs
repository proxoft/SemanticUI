using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Statistics
{
    [HtmlTargetElement("sui-statistic-label")]
    public class Label : SemanticTagHelper
    {
        public Label() : base("label", "div", false)
        {
        }

        protected override IEnumerable<string> Classes()
        {
            yield break;
        }
    }
}
