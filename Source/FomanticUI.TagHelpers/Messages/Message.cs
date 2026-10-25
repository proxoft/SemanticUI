using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Messages
{
    [HtmlTargetElement("fui-message")]
    public class Message : FomanticTagHelper
    {
        private MessageData _effective = new();

        public Message() : base("message", "div")
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var data = this.Data ?? new MessageData();
            _effective = data with
            {
                Severity = IsSet(context, nameof(this.Severity)) ? this.Severity : data.Severity,
                Size = IsSet(context, nameof(this.Size)) ? this.Size : data.Size,
                Color = IsSet(context, nameof(this.Color)) ? this.Color : data.Color,
                Icon = IsSet(context, nameof(this.IconName)) ? this.IconName : data.Icon,
                Header = IsSet(context, nameof(this.Header)) ? this.Header : data.Header,
                Content = IsSet(context, nameof(this.Content)) ? this.Content : data.Content,
                CanClose = IsSet(context, nameof(this.CanClose)) ? this.CanClose : data.CanClose,
                Floating = IsSet(context, nameof(this.Floating)) ? this.Floating : data.Floating,
                Items = IsSet(context, nameof(this.Items)) ? this.Items.ToArray() : data.Items
            };

            base.Process(context, output);

            if (this.HasIcon)
            {
                output.Content.AppendHtml($"<i class=\"{_effective.Icon} icon\"></i>");
            }

            output.Content.AppendHtml("<div class=\"content\">");
            if (this.HasHeader)
            {
                output.Content.AppendHtml($"<div class=\"header\">{_effective.Header}</div>");
            }

            if (this.HasContent)
            {
                output.Content.AppendHtml($"<p>{_effective.Content}</p>");
            }

            if (this.HasItems)
            {
                output.Content.AppendHtml($"<ul class=\"list\">");
                foreach (var item in _effective.Items)
                {
                    output.Content.AppendHtml($"<li>{item}</li>");
                }
                output.Content.AppendHtml("</ul>");
            }

            var childContent = await output.GetChildContentAsync();
            output.Content.AppendHtml(childContent);
            output.Content.AppendHtml("</div>");

            if (_effective.CanClose)
            {
                output.Content.AppendHtml("<i class=\"close icon\"></i>");
            }
        }

        /// <summary>
        /// All settings in one value; attributes written on the element override its values.
        /// </summary>
        public MessageData? Data { get; set; }

        public Severity Severity { get; set; }

        public Size Size { get; set; }

        public Color Color { get; set; }

        public string IconName { get; set; } = "";

        public string Header { get; set; } = "";

        public string Content { get; set; } = "";

        public bool CanClose { get; set; }

        public bool Floating { get; set; }

        public IEnumerable<string> Items { get; set; } = [];

        private bool HasIcon => !string.IsNullOrWhiteSpace(_effective.Icon);

        private bool HasHeader => !string.IsNullOrWhiteSpace(_effective.Header);

        private bool HasContent => !string.IsNullOrWhiteSpace(_effective.Content);

        private bool HasItems => _effective.Items.Count > 0;

        protected override IEnumerable<string> Classes()
        {
            yield return "icon".ToClassIf(this.HasIcon);
            yield return _effective.Severity.ToClass();

            if (_effective.Severity == Severity.NoSeverity)
            {
                yield return _effective.Color.ToClass();
            }

            yield return _effective.Size.ToClass();
            yield return "floating".ToClassIf(_effective.Floating);
        }
    }
}
