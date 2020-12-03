namespace Proxoft.SemanticUI.Core
{
    public enum Emphasizes
    {
        NoEmphasizes,
        Primary,
        Secondary,
        Positive,
        Approve,
        Ok,
        Negative,
        Deny,
        Cancel
    }

    public static class EmphasizesExtensions
    {
        public static string ToClass(this Emphasizes emphasizes)
        {
            return emphasizes == Emphasizes.NoEmphasizes
                ? string.Empty
                : emphasizes.ToString().ToLower();
        }
    }
}
