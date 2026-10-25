namespace Proxoft.FomanticUI.Core
{
    public record ButtonsGroupData : ButtonBaseData
    {
        public Orientation Orientation { get; init; } = Orientation.Horizontal;

        public Amount Amount { get; init; }
    }
}
