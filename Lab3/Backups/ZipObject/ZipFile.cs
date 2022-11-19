using System.IO.Compression;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public class ZipFile : IZipObject
{
    public ZipFile(IPath name)
    {
        NameRepo = name;
        NameZip = new Path.Path($"{name.Name}.zip");
    }

    public IPath NameRepo { get; }
    public IPath NameZip { get; }

    public IRepoObject ReturnRepoObject(ZipArchiveEntry entry)
    {
        return new RepoFile(entry.Open, NameRepo);
    }
}