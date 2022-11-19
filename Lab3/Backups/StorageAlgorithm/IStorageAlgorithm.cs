using Backups.BackupObject;
using Backups.Path;
using Backups.Repository;
using Backups.Storage;
using Backups.StorageAlgorithm;
namespace Backups.StorageAlgorithm;

public interface IStorageAlgorithm
{
    public IStorage Run(IReadOnlyCollection<BackupObject.BackupObject> listBackupObjects, IRepository repository, Archiver.Archiver archiver, IPath path);
}