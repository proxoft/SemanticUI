namespace Proxoft.SemanticUI.Core
{
    public enum State
    {
        NoState,
        Positive,
        Negative
    }

    public static class StateExtensions
    {
        public static string ToClass(this State state)
        {
            return state == State.NoState
                ? string.Empty
                : state.ToString().ToLower();
        }
    }
}
