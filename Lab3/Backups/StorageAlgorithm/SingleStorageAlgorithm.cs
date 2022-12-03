using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;

namespace Backups.StorageAlgorithm;

public class SingleStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Run(IReadOnlyCollection<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, IPath path)
    {
        var listRepoObjects = listBackupObjects
            .Select(backupObject => backupObject
                .ReturnRepoObject())
            .ToList();
        return archiver.CreateArchiver(listRepoObjects, repository, path);
    }
}