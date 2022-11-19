using Backups.RepoObject;

namespace Backups.Repository;

public class Repository : IRepository
{
    private Func<string, Stream> _fileFunc;
    private Func<string, IReadOnlyCollection<IRepoObject>> _folderFunc;

    public Repository(string repoPath)
    {
        Path = repoPath; // TODO: validate
        _fileFunc = (path) => this.ReturnRepoFile(path);
        _folderFunc = (path) => this.ConstructRepoFolder(path);
    }

    public string Path { get; }

    public Stream OpenWrite(string path)
    {
        string fullPath = $"{Path}{path}";
        return File.Open(path, FileMode.OpenOrCreate);
    }

    public IRepoObject ReturnRepoObject(string key)
    {
        string fullPath = $"{Path}{key}";
        FileAttributes backupObjectAttributes = File.GetAttributes(fullPath);
        if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
        {
            return new RepoFolder(() => _folderFunc(fullPath), key); // TODO: доставать имя
        }
        else
        {
            return new RepoFile(() => _fileFunc(fullPath), key); // TODO: нужно доставать из пути имя
        }
    }

    public IReadOnlyCollection<IRepoObject> ConstructRepoFolder(string path)
    {
        var listRepoObjects = new List<IRepoObject>();
        foreach (var repoObject in Directory.GetFiles(path))
        {
            FileAttributes backupObjectAttributes = File.GetAttributes(repoObject);
            if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                listRepoObjects.Add(new RepoFolder(() => _folderFunc(repoObject), repoObject));
            }
            else
            {
                listRepoObjects.Add(new RepoFile(() => _fileFunc(repoObject), repoObject)); // TODO: доставать имя из пути
            }
        }

        return listRepoObjects;
    }

    public Stream ReturnRepoFile(string path)
    {
        return File.Open(path, FileMode.Open);
    }
}