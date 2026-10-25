namespace Proxoft.FomanticUI.Core
{
    /// <summary>
    /// All icon settings in one immutable value, e.g. <c>new IconData("user", Size.Large)</c>;
    /// derive variants with <c>data with { Color = Color.Red }</c>.
    /// </summary>
    public record IconData(
        string Name = "",
        Size Size = Size.Undefined,
        Color Color = Color.NoColor,
        IconDecorations Decorations = IconDecorations.NoDecoration,
        Position Corner = Position.Default)
    {
        public string ToClass() => this.Classes().ToClass();

        private IEnumerable<string> Classes()
        {
            yield return this.Name;
            yield return this.Size.ToClass();
            yield return this.Color.ToClass();
            yield return this.Decorations.ToClass();
            yield return this.Corner.ToCornerClass();
        }
    }
}
