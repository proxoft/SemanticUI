using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Common.Items
{
    [HtmlTargetElement("fui-link-item")]
    public class LinkItem : AnchorTagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LinkItem(IHttpContextAccessor httpContextAccessor, IHtmlGenerator generator) : base(generator)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Color Color { get; set; }

        public bool IsActive { get; set; }

        public bool IsHeader { get; set; }

        public string? RightIcon { get; set; }

        public ActiveUrlMatch ActiveUrlMatch { get; set; } = ActiveUrlMatch.Exact;

        protected bool HasRightIcon => !string.IsNullOrWhiteSpace(this.RightIcon);

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;

            output.Attributes.Add("class", this.CreateClasses().ToClass());

            if (!string.IsNullOrWhiteSpace(this.RightIcon))
            {
                var iconClass = $"ui {this.RightIcon} icon";
                output.PostContent.SetHtmlContent($"<i class=\"{iconClass}\"></i>");
            }
        }

        private IEnumerable<string> CreateClasses()
        {
            yield return "header".ToClassIf(this.IsHeader);
            yield return "active".ToClassIf(this.IsActiveClass());
            yield return this.Color.ToClass();
            yield return "item";
        }

        private bool IsActiveClass()
        {
            if (this.IsActive)
            {
                return true;
            }

            if (this.ActiveUrlMatch == ActiveUrlMatch.None || string.IsNullOrWhiteSpace(this.Page))
            {
                return false;
            }

            var request = _httpContextAccessor.HttpContext?.Request;
            if (request is null)
            {
                return false;
            }

            var path = request.Path.ToString();
            if (this.ActiveUrlMatch == ActiveUrlMatch.Exact)
            {
                path += "/Index";
            }

            return path.Contains(this.Page, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
