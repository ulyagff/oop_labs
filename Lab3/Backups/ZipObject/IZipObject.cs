using System.IO.Compression;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public interface IZipObject
{
    public IPath NameRepo { get; }
    public IPath NameZip { get; }

    public IRepoObject ReturnRepoObject(ZipArchiveEntry entry);
}