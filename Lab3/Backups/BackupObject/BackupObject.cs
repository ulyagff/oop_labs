using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.BackupObject;

public class BackupObject
{
    private readonly IRepository _repository;

    public BackupObject(IRepository repository, IPath key)
    {
        _repository = repository;
        Key = key;
    }

    public IPath Key { get; }

    public IRepoObject ReturnRepoObject()
    {
        return _repository.ReturnRepoObject(Key);
    }
}