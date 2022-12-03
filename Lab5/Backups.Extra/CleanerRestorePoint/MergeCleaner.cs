using Backups.BackupTask;
using Backups.Extra.BackupDecorator;
using Backups.Extra.DecoratorRepository;
using Backups.RepoObject;

namespace Backups.Extra.CleanerRestorePoint;

public class MergeCleaner : ICleaner
{
    public void Clear(IBackupDecorator backup, IReadOnlyCollection<RestorePoint> restorePointsToDelete, IDecoratorRepository repository)
    {
        var backupObjects = restorePointsToDelete
            .SelectMany(i => i.Storage.ReturnRepoObjects())
            .Distinct()
            .Select(i => new BackupObject.BackupObject(repository, i.Name))
            .ToList();
        backup.AddRestorePoint(new RestorePoint(backupObjects, restorePointsToDelete.First().Storage, DateTime.Now));
    }
}