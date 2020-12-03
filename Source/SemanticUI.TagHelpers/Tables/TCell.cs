using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers
{
    public abstract class TCell : TRowCell
    {
        public TCell(string tagName) : base(tagName)
        {
        }

        public Position Alignment { get; set; } = Position.Default;

        public bool Collapsing { get; set; }

        public int RowSpan { get; set; }

        public int ColSpan { get; set; }

        public Amount Wide { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            if(this.ColSpan > 1)
            {
                output.Attributes.SetAttribute("colspan", this.ColSpan);
            }

            if(this.RowSpan > 1)
            {
                output.Attributes.SetAttribute("rowspan", this.ColSpan);
            }
        }

        protected override IEnumerable<string> Classes()
        {
            return base.Classes()
                .Concat(this.ClassesPrivate());
        }

        private IEnumerable<string> ClassesPrivate()
        {
            yield return "collapsing".ToClassIf(this.Collapsing);
            yield return this.Alignment.ToAlignmentClass();
            yield return this.Wide.ToClass("wide");
        }
    }
}
