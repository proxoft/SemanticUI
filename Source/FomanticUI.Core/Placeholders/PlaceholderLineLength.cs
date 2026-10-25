namespace Proxoft.FomanticUI.Core
{
    public enum PlaceholderLineLength
    {
        Default,
        Full,
        VeryLong,
        Long,
        Medium,
        Short,
        VeryShort
    }

    public static class PlaceholderLineLengthExtensions
    {
        public static string ToClass(this PlaceholderLineLength length)
        {
            return length switch
            {
                PlaceholderLineLength.Default => string.Empty,
                PlaceholderLineLength.VeryLong => "very long",
                PlaceholderLineLength.VeryShort => "very short",
                _ => length.ToString().ToLower()
            };
        }
    }
}
