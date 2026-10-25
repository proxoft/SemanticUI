using System.Collections.Generic;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers
{
    public abstract class LabelBase : FomanticTagHelper
    {
        public LabelBase() : base("label", "div")
        {
        }

        public Color Color { get; set; }

        public Size Size { get; set; }

        protected override IEnumerable<string> Classes()
        {
            yield return this.Color.ToClass();
            yield return this.Size.ToClass();
        }
    }
}
