using Proxoft.FomanticUI.Resources;

namespace Microsoft.AspNetCore.Builder;

public static class FomanticCoreDependencies
{
    /// <summary>
    ///     Enables Fomantic UI resources (css, js and fonts)
    /// </summary>
    /// <param name="app"></param>
    /// <param name="requestPath">
    ///     the request path must correspond with <link rel="stylesheet" href="/{requestPath}/semantic.min.css" />
    ///     e.g. requestPath = '/fomantic-ui-folder'
    ///     and the link <link rel="stylesheet" href="/fomantic-ui-folder/semantic.min.css" />
    /// </param>
    /// <returns></returns>
    public static IApplicationBuilder UseFomanticUiResources(this IApplicationBuilder app, string requestPath = "/fomantic-ui")
    {
        app.UseStaticFiles(new StaticFileOptions
        {
            RequestPath = requestPath.PrefixSlash(),
            FileProvider = new ResourceFileProvider()
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