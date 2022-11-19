using System.IO.Compression;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;
using Backups.Visitor;

namespace Backups.Archiver;

public class Archiver
{
    private readonly IRepository _repository;
    public Archiver(IRepository repository)
    {
        _repository = repository;
    }

    public ZipStorage CreateArchiver(List<IRepoObject> listRepoObject, IRepository repository, IPath key)
    {
        using Stream temp = repository.OpenWrite(key);
        using ZipArchive mainArchive = new ZipArchive(temp, ZipArchiveMode.Create);
        ZipArchiveVisitor visitor = new ZipArchiveVisitor(mainArchive);
        foreach (IRepoObject repoObject in listRepoObject)
        {
            repoObject.Accept(visitor);
        }

        return new ZipStorage(_repository, visitor.FinalZipObject(key), key);
    }
}