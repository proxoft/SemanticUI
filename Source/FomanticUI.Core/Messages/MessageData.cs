namespace Proxoft.FomanticUI.Core;

/// <summary>
///     All message settings in one immutable value; derive variants with <c>data with { ... }</c>.
/// </summary>
public record MessageData
{
    public Severity Severity { get; init; } = Severity.NoSeverity;

    public Size Size { get; init; } = Size.Undefined;

    public Color Color { get; init; } = Color.NoColor;

    public string Icon { get; init; } = "";

    public string Header { get; init; } = "";

    public string Content { get; init; } = "";

    public bool CanClose { get; init; }

    public bool Floating { get; init; }

    public IReadOnlyList<string> Items { get; init; } = [];
}