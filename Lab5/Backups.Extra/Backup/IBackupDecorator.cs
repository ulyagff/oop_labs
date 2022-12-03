using Backups.BackupTask;

namespace Backups.Extra.BackupDecorator;

public interface IBackupDecorator : IBackup
{
    public void DeleteRestorePoint(RestorePoint restorePoint);
}