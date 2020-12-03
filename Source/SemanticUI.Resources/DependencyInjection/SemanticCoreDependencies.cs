namespace Microsoft.AspNetCore.Builder
{
    public static class SemanticCoreDependencies
    {
        /// <summary>
        /// Enables semantuic.ui resources (css and js)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="requestPath">
        /// the request path must correspond with <link rel="stylesheet" href="/{requestPath}/semantic.min.css" />
        /// e.g. requestPath = '/semantic-ui-folder'
        /// and the link <link rel="stylesheet" href="/semantic-ui-folder/semantic.min.css" />
        /// </param>
        /// <returns></returns>
        public static IApplicationBuilder UseSemanticUiResources(this IApplicationBuilder app, string requestPath = "/semantic-ui")
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                RequestPath = requestPath.PrefixSlash(),
                FileProvider = new Proxoft.SemanticUI.Resources.ResourceFileProvider()
            });

            return app;
        }

        private static string PrefixSlash(this string value)
        {
            return value?.StartsWith("/") ?? false
                ? value
                : "/" + value;
        }
    }
}
