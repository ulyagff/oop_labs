using Backups.RepoObject;
using Zio;
using Zio.FileSystems;

namespace Backups.Repository;

public class InMemoryRepository : IRepository, IDisposable
{
    private readonly MemoryFileSystem _fileSystem;
    private Func<string, Stream> _fileFunc;
    private Func<string, IReadOnlyCollection<IRepoObject>> _folderFunc;

    public InMemoryRepository(MemoryFileSystem fileSystem, string path)
    {
        _fileSystem = fileSystem;
        Path = path;
        _fileFunc = (path) => this.ReturnRepoFile(path);
        _folderFunc = (path) => this.ConstructRepoFolder(path);
    }

    public string Path { get; }

    public Stream OpenWrite(string path)
    {
        string fullPath = $"{Path}{path}";
        return _fileSystem.OpenFile(fullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    public IRepoObject ReturnRepoObject(string key)
    {
        string fullPath = $"{Path}{key}";
        FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(fullPath);
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
        foreach (var repoObject in _fileSystem.EnumerateFiles(path))
        {
            FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(repoObject);
            if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                listRepoObjects.Add(new RepoFolder(() => _folderFunc(repoObject.ToString()), repoObject.GetName()));
            }
            else
            {
                listRepoObjects.Add(new RepoFile(() => _fileFunc(repoObject.ToString()), repoObject.GetName())); // TODO: доставать имя из пути
            }
        }

        return listRepoObjects;
    }

    public Stream ReturnRepoFile(string path)
    {
        return _fileSystem.OpenFile(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    public void Dispose()
    {
        _fileSystem.Dispose();
    }
}