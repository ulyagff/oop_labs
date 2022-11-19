using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public class ZipFile : IZipObject
{
    public ZipFile(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IRepoObject ReturnRepoObject(string pathToZip, IRepository repository)
    {
        return repository.ReturnRepoObject($"{pathToZip}{Name}");
    }
}