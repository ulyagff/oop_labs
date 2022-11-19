using Backups.Path;
using Backups.RepoObject;

namespace Backups.Repository;

public class Repository : IRepository
{
    private Func<IPath, Stream> _fileFunc;
    private Func<IPath, IReadOnlyCollection<IRepoObject>> _folderFunc;
    public Repository(IPath basePath)
    {
        BasePath = basePath;
        _fileFunc = (path) => this.ReturnRepoFile(path);
        _folderFunc = (path) => this.ConstructRepoFolder(path);
    }

    public IPath BasePath { get; }

    public Stream OpenWrite(IPath path)
    {
        return File.Open(BasePath.ConcatinatePath(path), FileMode.OpenOrCreate, FileAccess.Write);
    }

    public IRepoObject ReturnRepoObject(IPath key)
    {
        FileAttributes backupObjectAttributes = File.GetAttributes(BasePath.ConcatinatePath(key));
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

    private IReadOnlyCollection<IRepoObject> ConstructRepoFolder(IPath fullPath)
    {
        var listRepoObjects = new List<IRepoObject>();
        foreach (var repoObject in Directory.GetFiles(fullPath.ToString()))
        {
            FileAttributes backupObjectAttributes = File.GetAttributes(repoObject);
            IPath pathToSubRepoObject = new Path.Path(repoObject);
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
        return File.Open(fullPath.ToString(), FileMode.Open, FileAccess.ReadWrite);
    }
}