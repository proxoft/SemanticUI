using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-ribbonLabel")]
    public class RibbonLabel : LabelBase
    {
        public Position Position { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Position.ToLabelClass(),
                    "ribbon"
                });
        }
    }
}
