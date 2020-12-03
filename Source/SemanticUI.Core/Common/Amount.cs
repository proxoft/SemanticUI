namespace Proxoft.SemanticUI.Core
{
    public enum Amount
    {
        Undefined,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen,
        Fourteen,
        Fifteen,
        Sixteen
    }

    public static class AmountExtensions
    {
        public static string ToClass(this Amount count, string of)
        {
            if(count == Amount.Undefined)
            {
                return string.Empty;
            }

            var suffix = string.IsNullOrEmpty(of) ? string.Empty : " " + of;
            return count.ToString().ToLower() + suffix;
        }
    }
}
