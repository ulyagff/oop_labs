using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;

namespace Backups.StorageAlgorithm;

public class SingleStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Run(List<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, string name)
    {
        var listRepoObjects = new List<IRepoObject>();
        foreach (var backupObject in listBackupObjects)
        {
            listRepoObjects.Add(backupObject.ReturnRepoObject());
        }

        return archiver.CreateArchiver(listRepoObjects, repository, name);
    }
}