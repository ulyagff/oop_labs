using Backups.RepoObject;
using Backups.Repository;
using Backups.Storage;

namespace Backups.StorageAlgorithm;

public class SplitStorageAlgorithm : IStorageAlgorithm
{
    public IStorage Run(List<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, string name)
    {
        var storages = new List<ZipStorage>();
        foreach (var backupObject in listBackupObjects)
        {
            var listRepoObjects = new List<IRepoObject>();
            listRepoObjects.Add(backupObject.ReturnRepoObject());
            storages.Add(archiver.CreateArchiver(listRepoObjects, repository, name));
        }

        return new SplitStorage(storages);
    }
}