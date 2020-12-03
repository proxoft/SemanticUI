namespace Proxoft.SemanticUI.Core
{
    public abstract class ButtonBaseData
    {
        public Color Color { get; set; }

        public Size Size { get; set; }

        public ButtonDecoration Decoration { get; set; }

        public Position Floated { get; set; }

        public Position Attached { get; set; }

        public bool IsVisible { get; set; } = true;

        public bool Fluid { get; set; } = false;
    }
}
