using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;

namespace Backups.StorageAlgorithm;

public class SplitStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Run(IReadOnlyCollection<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, IPath path)
    {
        var storages = listBackupObjects
            .Select(backupObject => new List<IRepoObject> { backupObject.ReturnRepoObject() })
            .Select(listRepoObjects => archiver.CreateArchiver(listRepoObjects, repository, path))
            .ToList();

        return new SplitStorage(storages);
    }
}