using Backups.BackupObject;
using Backups.Repository;
using Backups.Storage;
using Backups.StorageAlgorithm;
namespace Backups.StorageAlgorithm;

public interface IStorageAlgorithm
{
    public IStorage Run(List<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, string name);
}