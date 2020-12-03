namespace Proxoft.SemanticUI.Core
{
    public class MessageData
    {
        public Severity Severity { get; set; } = Severity.NoSeverity;

        public Size Size { get; set; } = Size.Undefined;

        public Color Color { get; set; } = Color.NoColor;

        public string Icon { get; set; }

        public string Header { get; set; }

        public string Content { get; set; }

        public bool CanClose { get; set; }

        public bool Floating { get; set; }

        public string[] Items { get; set; }
    }
}
