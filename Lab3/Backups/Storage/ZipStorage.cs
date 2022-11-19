using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;
using Backups.ZipObject;
using ZipFile = Backups.ZipObject.ZipFile;

namespace Backups.Storage;

public class ZipStorage : IStorage
{
    private readonly IRepository _repository;
    private readonly ZipFolder _zipFolder;
    private readonly string _pathToZip;

    public ZipStorage(IRepository repository, ZipFolder zipFolder, string pathToZip)
    {
        _repository = repository;
        _zipFolder = zipFolder;
        _pathToZip = pathToZip;
    }

    public List<IRepoObject> ReturnRepoObjects()
    {
        var listRepoObjects = new List<IRepoObject>();
        Stream temp = _repository.OpenWrite(_pathToZip);
        var zipArchive = new ZipArchive(temp);
        foreach (var entry in zipArchive.Entries)
        {
            IZipObject zipObject = _zipFolder
                .ListZipObjects()
                .First(i => i.Name == entry.Name);
            listRepoObjects.Add(zipObject.ReturnRepoObject(_pathToZip, _repository));
        }

        return listRepoObjects;
    }
}