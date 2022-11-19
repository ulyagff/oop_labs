using System.IO.Compression;
using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;
using Backups.Visitor;

namespace Backups.Archiver;

public class Archiver
{
    private readonly IRepository _repository;
    private string _key;
    private string name;
    public Archiver(IRepository repository, string key)
    {
        _repository = repository;
        _key = key;
        name = key;
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
            string temp = _key;
            _key = $"{temp}/{value}";
        }
    }

    public ZipStorage CreateArchiver(List<IRepoObject> listRepoObject, IRepository repository, string name)
    {
        Name = name;
        using Stream temp = repository.OpenWrite(_key);
        using ZipArchive mainArchive = new ZipArchive(temp, ZipArchiveMode.Create);
        ZipArchiveVisitor visitor = new ZipArchiveVisitor(mainArchive);
        foreach (IRepoObject repoObject in listRepoObject)
        {
            repoObject.Accept(visitor);
        }

        return new ZipStorage(_repository, visitor.FinalZipObject(_key), _key);
    }
}