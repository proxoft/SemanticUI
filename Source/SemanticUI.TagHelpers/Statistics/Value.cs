using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Statistics
{
    [HtmlTargetElement("sui-statistic-value")]
    public class Value : SemanticTagHelper
    {
        public Value() : base("value", "div", false)
        {
        }

        public bool IsTextValue { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return "text".ToClassIf(this.IsTextValue);
        }
    }
}
