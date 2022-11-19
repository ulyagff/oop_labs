using System.IO.Compression;
using Backups.BackupsException;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;
using Backups.ZipObject;
using ZipFile = Backups.ZipObject.ZipFile;

namespace Backups.Storage;

public class ZipStorage : IStorage
{
    private readonly IRepository _repository;
    private readonly ZipFolder _zipFolder;
    private readonly IPath _pathToZip;

    public ZipStorage(IRepository repository, ZipFolder zipFolder, IPath pathToZip)
    {
        _repository = repository;
        _zipFolder = zipFolder;
        _pathToZip = pathToZip;
    }

    public IReadOnlyCollection<IRepoObject> ReturnRepoObjects()
    {
        IRepoObject repoObject = _repository.ReturnRepoObject(_pathToZip);
        RepoFile archive = repoObject as RepoFile ?? throw RepoObjectException.ExpectedRepoFile();
        using Stream archiveStream = archive.OpenStream();
        using var zipArchive = new ZipArchive(archiveStream);

        return (from entry in zipArchive.Entries
            let zipObject = _zipFolder.ListZipObjects()
                .First(i => i.NameZip.Name == entry.Name)
            select zipObject.ReturnRepoObject(entry)).ToList();
    }
}