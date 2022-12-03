namespace Backups.BackupTask;

public interface IBackup
{
    public IReadOnlyCollection<RestorePoint> BackupHistory { get; }
    public void AddRestorePoint(RestorePoint restorePoint);
}