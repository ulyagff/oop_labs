using Backups.Path;
using Backups.RepoObject;
using Zio;
using Zio.FileSystems;

namespace Backups.Repository;

public class InMemoryRepository : IRepository, IDisposable
{
    private readonly MemoryFileSystem _fileSystem;
    private Func<IPath, Stream> _fileFunc;
    private Func<IPath, IReadOnlyCollection<IRepoObject>> _folderFunc;

    public InMemoryRepository(MemoryFileSystem fileSystem, IPath basePath)
    {
        _fileSystem = fileSystem;
        BasePath = basePath;
        _fileFunc = (path) => this.ReturnRepoFile(path);
        _folderFunc = (path) => this.ConstructRepoFolder(path);
    }

    public IPath BasePath { get; }

    public Stream OpenWrite(IPath path)
    {
        return _fileSystem.OpenFile(BasePath.ConcatinatePath(path), FileMode.OpenOrCreate, FileAccess.Write);
    }

    public IRepoObject ReturnRepoObject(IPath key)
    {
        FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(BasePath.ConcatinatePath(key));
        var fullPath = new Path.Path(BasePath.ConcatinatePath(key));
        var nameRepoObject = new Path.Path(key.Name);
        if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
        {
            return new RepoFolder(() => _folderFunc(fullPath), nameRepoObject);
        }
        else
        {
            return new RepoFile(() => _fileFunc(fullPath), nameRepoObject);
        }
    }

    public void Dispose()
    {
        _fileSystem.Dispose();
    }

    private IReadOnlyCollection<IRepoObject> ConstructRepoFolder(IPath fullPath)
    {
        var listRepoObjects = new List<IRepoObject>();
        foreach (var repoObject in _fileSystem.EnumerateFiles(fullPath.ToString()))
        {
            FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(repoObject);
            IPath pathToSubRepoObject = new Path.Path(repoObject.ToString());
            IPath nameSubRepoObject = new Path.Path(pathToSubRepoObject.Name);
            if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                listRepoObjects.Add(new RepoFolder(() => _folderFunc(pathToSubRepoObject), nameSubRepoObject));
            }
            else
            {
                listRepoObjects.Add(new RepoFile(() => _fileFunc(pathToSubRepoObject), nameSubRepoObject));
            }
        }

        return listRepoObjects;
    }

    private Stream ReturnRepoFile(IPath fullPath)
    {
        return _fileSystem.OpenFile(fullPath.ToString(), FileMode.Open, FileAccess.ReadWrite);
    }
}