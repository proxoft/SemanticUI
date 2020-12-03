namespace Proxoft.SemanticUI.Core
{
    public enum EditState
    {
        Edit,
        ReadOnly,
        Disabled
    }

    public static class EditStateExtensions
    {
        public static string ToClass(this EditState editState)
        {
            return editState switch
            {
                EditState.ReadOnly => "read-only",
                EditState.Disabled => "disabled",
                _ => string.Empty
            };
        }
    }
}
