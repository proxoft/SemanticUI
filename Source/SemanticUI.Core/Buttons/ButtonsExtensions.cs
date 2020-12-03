namespace Proxoft.SemanticUI.Core
{
    public static class ButtonsExtensions
    {
        public static string ToAttribute(this ButtonType buttonType)
        {
            return buttonType.ToString().ToLower();
        }
    }
}
