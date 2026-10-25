namespace Proxoft.FomanticUI.Core
{
    public record SingleButtonData : ButtonBaseData
    {
        public ButtonState State { get; init; }

        public Emphasizes Emphasizes { get; init; }
    }
}
