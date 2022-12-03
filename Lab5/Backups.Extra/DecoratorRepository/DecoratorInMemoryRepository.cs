using Backups.Extra.BackupExtraException;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;
using Zio.FileSystems;

namespace Backups.Extra.DecoratorRepository;

public class DecoratorRepository : IDecoratorRepository
{
    private InMemoryRepository _decoratee;
    private MemoryFileSystem _fileSystem;

    public DecoratorRepository(InMemoryRepository decoratee, MemoryFileSystem fileSystem)
    {
        _decoratee = decoratee;
        _fileSystem = fileSystem;
    }

    public Stream OpenWrite(IPath path)
    {
        return _decoratee.OpenWrite(path);
    }

    public IRepoObject ReturnRepoObject(IPath key)
    {
        return _decoratee.ReturnRepoObject(key);
    }

    public void DeleteRepoObject(IRepoObject repoObject)
    {
        var fullPath = new Path.Path(_decoratee.BasePath.ConcatinatePath(repoObject.Name));
        FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(fullPath.ToString());
        if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
        {
            _fileSystem.DeleteDirectory(fullPath.ToString(), true);
        }
        else
        {
            _fileSystem.DeleteFile(fullPath.ToString());
        }
    }

    public void MoveRepoObject(IRepoObject oldRepoObject, IRepoObject newRepoObject)
    {
        var oldFullPath = new Path.Path(_decoratee.BasePath.ConcatinatePath(oldRepoObject.Name));
        var newFullPath = new Path.Path(_decoratee.BasePath.ConcatinatePath(newRepoObject.Name));

        FileAttributes backupObjectAttributes = _fileSystem.GetAttributes(oldFullPath.ToString());
        FileAttributes newBackupObjectAttributes = _fileSystem.GetAttributes(newFullPath.ToString());
        if ((newBackupObjectAttributes & FileAttributes.Directory) != FileAttributes.Directory)
        {
            throw RepositoryExtraException.MoveObjectToFile();
        }

        if ((backupObjectAttributes & FileAttributes.Directory) == FileAttributes.Directory)
        {
            _fileSystem.MoveDirectory(oldFullPath.ToString(), newFullPath.ToString());
        }
        else
        {
            _fileSystem.MoveFile(oldFullPath.ToString(), newFullPath.ToString());
        }
    }
}