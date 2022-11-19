namespace Backups.BackupTask;

public interface IBackup
{
    public void AddRestorePoint(RestorePoint restorePoint);
}