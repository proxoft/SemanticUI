using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-label")]
    public class Label : LabelBase
    {
        public Position Attached { get; set; }

        public LabelDecorations Decorations { get; set; }

        public LabelPointing Pointing { get; set; }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(new[] {
                    this.Decorations.ToClass(),
                    this.Pointing.ToClass(),
                    this.Attached.ToAttachedClass()
                });
        }
    }
}
