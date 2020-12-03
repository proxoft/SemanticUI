using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.SemanticUI.Core;

namespace Proxoft.SemanticUI.TagHelpers.Messages
{
    [HtmlTargetElement("sui-message")]
    public class Message : SemanticTagHelper
    {
        private MessageData _data = new MessageData();

        public Message() : base("message", "div")
        {
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (this.HasIcon)
            {
                output.Content.AppendHtml($"<i class=\"{this.IconName} icon\"></i>");
            }

            output.Content.AppendHtml("<div class=\"content\">");
            if (this.HasHeader)
            {
                output.Content.AppendHtml($"<div class=\"header\">{this.Header}</div>");
            }

            if (this.HasContent)
            {
                output.Content.AppendHtml($"<p>{this.Content}</p>");
            }

            if (this.HasItems)
            {
                output.Content.AppendHtml($"<ul class=\"list\">");
                foreach (var item in this.Items)
                {
                    output.Content.AppendHtml($"<li>{item}</li>");
                }
                output.Content.AppendHtml("</ul>");
            }

            var childContent = await output.GetChildContentAsync();
            output.Content.AppendHtml(childContent);
            output.Content.AppendHtml("</div>");

            if (this.CanClose)
            {
                output.Content.AppendHtml("<i class=\"close icon\"></i>");
            }
        }

        public MessageData Data
        {
            get => _data;
            set => _data = value ?? new MessageData();
        }

        public Severity Severity
        {
            get => _data.Severity;
            set => _data.Severity = value;
        }

        public Size Size
        {
            get => _data.Size;
            set => _data.Size = value;
        }

        public Color Color
        {
            get => _data.Color;
            set => _data.Color = value;
        }

        public string IconName
        {
            get => _data.Icon;
            set => _data.Icon = value;
        }

        private bool HasIcon => !string.IsNullOrWhiteSpace(this.IconName);

        public string Header
        {
            get => _data.Header;
            set => _data.Header = value;
        }

        private bool HasHeader => !string.IsNullOrWhiteSpace(this.Header);

        public string Content
        {
            get => _data.Content;
            set => _data.Content = value;
        }

        private bool HasContent => !string.IsNullOrWhiteSpace(this.Content);

        public bool CanClose
        {
            get => _data.CanClose;
            set => _data.CanClose = value;
        }

        public bool Floating
        {
            get => _data.Floating;
            set => _data.Floating = value;
        }

        public IEnumerable<string> Items
        {
            get => _data.Items;
            set => _data.Items = value?.ToArray();
        }

        private bool HasItems => _data.Items?.Length > 0;

        protected override IEnumerable<string> Classes()
        {
            yield return "icon".ToClassIf(this.HasIcon);
            yield return this.Severity.ToClass();

            if (this.Severity == Severity.NoSeverity)
            {
                yield return this.Color.ToClass();
            }

            yield return this.Size.ToClass();
            yield return "floating".ToClassIf(this.Floating);
        }
    }
}
