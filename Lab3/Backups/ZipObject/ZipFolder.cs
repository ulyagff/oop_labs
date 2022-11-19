using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public class ZipFolder : IZipObject
{
    private List<IZipObject> _listZipObjects;
    public ZipFolder(string name, List<ZipObject.IZipObject> listZipObjects)
    {
        Name = name;
        _listZipObjects = listZipObjects;
    }

    public string Name { get; }

    public IReadOnlyCollection<IZipObject> ListZipObjects() => _listZipObjects;

    public IRepoObject ReturnRepoObject(string pathToZip, IRepository repository)
    {
        return repository.ReturnRepoObject($"{pathToZip}{Name}");
    }
}