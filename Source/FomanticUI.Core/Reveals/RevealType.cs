namespace Proxoft.FomanticUI.Core;

public enum RevealType
{
    Fade,
    Move,
    MoveRight,
    MoveUp,
    MoveDown,
    Rotate,
    RotateLeft
}

public static class RevealTypeExtensions
{
    public static string ToClass(this RevealType type)
    {
        return type switch
        {
            RevealType.MoveRight => "move right",
            RevealType.MoveUp => "move up",
            RevealType.MoveDown => "move down",
            RevealType.RotateLeft => "rotate left",
            _ => type.ToString().ToLower()
        };
    }
}