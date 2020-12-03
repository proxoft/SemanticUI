using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    [HtmlTargetElement("sui-menu")]
    public class Menu : MenuBase
    {
        public Menu() : base(true)
        {
        }

        public Size Size { get; set; }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes().Concat(new[] { this.Size.ToClass() } );
        }
    }
}
