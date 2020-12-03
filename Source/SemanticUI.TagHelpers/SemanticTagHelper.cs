using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

using System.Collections.Generic;
using System.Linq;

namespace Proxoft.SemanticUI.TagHelpers
{
    public abstract class SemanticTagHelper : TagHelper
    {
        protected SemanticTagHelper(
            string cssName,
            string tagName,
            bool prefixUi = true)
        {
            this.CssName = cssName;
            this.TagName = tagName;
            this.PrefixUi = prefixUi;
        }

        protected string TagName { get; }

        protected string CssName { get; }

        protected bool PrefixUi { get; set; }

        protected TagMode TagMode { get; set; } = TagMode.StartTagAndEndTag;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = this.TagName;
            output.TagMode = this.TagMode;

            output.Attributes.SetAttribute("class", this.Class());
        }

        protected string Class()
        {
            return new []
                {
                    "ui".ToClassIf(PrefixUi)
                }
                .Concat(this.Classes())
                .Concat(new[] { this.CssName })
                .Concat(this.AfterCssNameClasses())
                .ToClass();
        }

        protected abstract IEnumerable<string> Classes();

        protected virtual IEnumerable<string> AfterCssNameClasses()
        {
            yield break;
        }
    }
}
