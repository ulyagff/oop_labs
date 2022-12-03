using Backups.BackupTask;
using Backups.Extra.BackupDecorator;
using Backups.Extra.DecoratorRepository;
using Backups.RepoObject;

namespace Backups.Extra.CleanerRestorePoint;

public class DeleteCleaner : ICleaner
{
    public void Clear(IBackupDecorator backup, IReadOnlyCollection<RestorePoint> restorePointsToDelete, IDecoratorRepository repository)
    {
        foreach (RestorePoint restorePoint in restorePointsToDelete)
        {
            backup.DeleteRestorePoint(restorePoint);
            foreach (IRepoObject repoObject in restorePoint.Storage.ReturnRepoObjects())
            {
                repository.DeleteRepoObject(repoObject);
            }
        }
    }
}