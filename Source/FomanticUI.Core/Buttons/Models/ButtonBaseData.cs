namespace Proxoft.FomanticUI.Core
{
    public abstract record ButtonBaseData
    {
        public Color Color { get; init; }

        public Size Size { get; init; }

        public ButtonDecoration Decoration { get; init; }

        public Position Floated { get; init; }

        public Position Attached { get; init; }

        public bool IsVisible { get; init; } = true;

        public bool Fluid { get; init; }
    }
}
