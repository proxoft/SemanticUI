using static Proxoft.FomanticUI.Core.ButtonState;

namespace Proxoft.FomanticUI.Core;

public enum ButtonState
{
    Enabled,
    Active,
    Disabled,
    Loading
}

public static class ButtonStateExtensions
{
    public static string ToClass(this ButtonState state)
    {
        return state == Enabled
            ? string.Empty
            : state.ToString().ToLower();
    }
}