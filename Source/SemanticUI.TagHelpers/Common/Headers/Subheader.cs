using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Proxoft.SemanticUI.TagHelpers.Common.Headers
{
    [HtmlTargetElement("sui-subheader")]
    public class Subheader : HeaderBase
    {
        public Subheader() : base("sub header", false)
        {
        }

        public bool IsRoot
        {
            get => this.PrefixUi;
            set => this.PrefixUi = value;
        }
    }
}
