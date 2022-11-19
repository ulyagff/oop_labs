using Backups.RepoObject;
using Backups.Repository;

namespace Backups.BackupObject;

public class BackupObject
{
    private readonly IRepository _repository;

    public BackupObject(IRepository repository, string key, string name)
    {
        _repository = repository;
        Key = key;
    }

    public string Key { get; }

    public IRepoObject ReturnRepoObject()
    {
        return _repository.ReturnRepoObject(Key);
    }
}