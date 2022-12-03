using Backups.BackupTask;
using Backups.Extra.BackupDecorator;
using Backups.Extra.DecoratorRepository;

namespace Backups.Extra.CleanerRestorePoint;

public interface ICleaner
{
    public void Clear(IBackupDecorator backup, IReadOnlyCollection<RestorePoint> restorePointsToDelete, IDecoratorRepository repository);
}