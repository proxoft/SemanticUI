namespace Proxoft.FomanticUI.Core
{
    /// <summary>
    /// Animation of a progress whose value is unknown.
    /// </summary>
    public enum ProgressIndeterminate
    {
        None,
        Default,
        Sliding,
        Filling,
        Swinging
    }

    public static class ProgressIndeterminateExtensions
    {
        public static string ToClass(this ProgressIndeterminate indeterminate)
        {
            return indeterminate switch
            {
                ProgressIndeterminate.None => string.Empty,
                ProgressIndeterminate.Default => "indeterminate",
                _ => $"{indeterminate.ToString().ToLower()} indeterminate"
            };
        }
    }
}
