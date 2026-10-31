namespace Proxoft.FomanticUI.Core;

public record Tooltip(
    string Content = "",
    Position Position = Position.TopRight,
    bool InvertedTooltip = false);