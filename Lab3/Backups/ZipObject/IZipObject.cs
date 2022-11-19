using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public interface IZipObject
{
    public string Name { get; }

    public IRepoObject ReturnRepoObject(string pathToZip, IRepository repository);
}