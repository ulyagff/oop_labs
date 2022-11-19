using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;
using Backups.ZipObject;

namespace Backups.Storage;

public class SplitStorage : IStorage
{
    private List<ZipStorage> _listZipStorage;
    public SplitStorage(List<ZipStorage> listZipStorage)
    {
        _listZipStorage = listZipStorage;
    }

    public List<IRepoObject> ReturnRepoObjects()
    {
        var listRepoObjects = new List<IRepoObject>();
        foreach (var storage in _listZipStorage)
        {
            listRepoObjects.Add(storage.ReturnRepoObjects().First());
        }

        return listRepoObjects;
    }
}