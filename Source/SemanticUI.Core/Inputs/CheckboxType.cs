namespace Proxoft.SemanticUI.Core
{
    public enum CheckboxType
    {
        Checkbox,
        Radio,
        Slider,
        Toggle
    }

    public static class CheckboxTypeExtensions
    {
        public static string ToClass(this CheckboxType type)
        {
            return type.ToString().ToLower();
        }
    }
}
