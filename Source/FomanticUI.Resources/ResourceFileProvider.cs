using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace Proxoft.FomanticUI.Resources;

public class ResourceFileProvider : IFileProvider
{
    private const string _assemblyPath = "fomantic";
    private readonly ManifestEmbeddedFileProvider _provider = new(typeof(ResourceFileProvider).Assembly);

    public IDirectoryContents GetDirectoryContents(string subpath)
    {
        IDirectoryContents result = _provider.GetDirectoryContents(_assemblyPath + subpath);
        return result;
    }

    public IFileInfo GetFileInfo(string subpath)
    {
        IFileInfo result = _provider.GetFileInfo(_assemblyPath + subpath);
        return result;
    }

    public IChangeToken Watch(string filter)
    {
        IChangeToken result = _provider.Watch(_assemblyPath + filter);
        return result;
    }
}