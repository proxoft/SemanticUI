using Microsoft.AspNetCore.Razor.TagHelpers;
using Proxoft.FomanticUI.Core;

namespace Proxoft.FomanticUI.TagHelpers.Messages;

[HtmlTargetElement("fui-message")]
public class Message : FomanticTagHelper
{
    private MessageData _effective = new();

    public Message() : base("message", "div")
    {
    }

    /// <summary>
    ///     All settings in one value; attributes written on the element override its values.
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

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        MessageData data = Data ?? new MessageData();
        _effective = data with
        {
            Severity = IsSet(context, nameof(Severity)) ? Severity : data.Severity,
            Size = IsSet(context, nameof(Size)) ? Size : data.Size,
            Color = IsSet(context, nameof(Color)) ? Color : data.Color,
            Icon = IsSet(context, nameof(IconName)) ? IconName : data.Icon,
            Header = IsSet(context, nameof(Header)) ? Header : data.Header,
            Content = IsSet(context, nameof(Content)) ? Content : data.Content,
            CanClose = IsSet(context, nameof(CanClose)) ? CanClose : data.CanClose,
            Floating = IsSet(context, nameof(Floating)) ? Floating : data.Floating,
            Items = IsSet(context, nameof(Items)) ? Items.ToArray() : data.Items
        };

        base.Process(context, output);

        if (HasIcon) output.Content.AppendHtml($"<i class=\"{_effective.Icon} icon\"></i>");

        output.Content.AppendHtml("<div class=\"content\">");
        if (HasHeader) output.Content.AppendHtml($"<div class=\"header\">{_effective.Header}</div>");

        if (HasContent) output.Content.AppendHtml($"<p>{_effective.Content}</p>");

        if (HasItems)
        {
            output.Content.AppendHtml("<ul class=\"list\">");
            foreach (var item in _effective.Items) output.Content.AppendHtml($"<li>{item}</li>");
            output.Content.AppendHtml("</ul>");
        }

        TagHelperContent childContent = await output.GetChildContentAsync();
        output.Content.AppendHtml(childContent);
        output.Content.AppendHtml("</div>");

        if (_effective.CanClose) output.Content.AppendHtml("<i class=\"close icon\"></i>");
    }

    protected override IEnumerable<string> Classes()
    {
        yield return "icon".ToClassIf(HasIcon);
        yield return _effective.Severity.ToClass();

        if (_effective.Severity == Severity.NoSeverity) yield return _effective.Color.ToClass();

        yield return _effective.Size.ToClass();
        yield return "floating".ToClassIf(_effective.Floating);
    }
}