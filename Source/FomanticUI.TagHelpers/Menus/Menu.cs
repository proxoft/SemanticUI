using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    [HtmlTargetElement("fui-menu")]
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
