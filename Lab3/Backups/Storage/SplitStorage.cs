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

    public IReadOnlyCollection<IRepoObject> ReturnRepoObjects()
    {
        return _listZipStorage
            .Select(storage => storage.ReturnRepoObjects()
            .First())
            .ToList();
    }
}