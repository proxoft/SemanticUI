namespace Proxoft.FomanticUI.Core;

/// <summary>
///     All icon settings in one immutable value, e.g. <c>new IconData("user", Size.Large)</c>;
///     derive variants with <c>data with { Color = Color.Red }</c>.
/// </summary>
public record IconData(
    string Name = "",
    Size Size = Size.Undefined,
    Color Color = Color.NoColor,
    IconDecorations Decorations = IconDecorations.NoDecoration,
    Position Corner = Position.Default)
{
    public string ToClass()
    {
        return Classes().ToClass();
    }

    private IEnumerable<string> Classes()
    {
        yield return Name;
        yield return Size.ToClass();
        yield return Color.ToClass();
        yield return Decorations.ToClass();
        yield return Corner.ToCornerClass();
    }
}