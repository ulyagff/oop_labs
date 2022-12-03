namespace Backups.BackupTask;

public class Backup : IBackup
{
    private List<RestorePoint> _backupHistory;

    public Backup()
    {
        _backupHistory = new List<RestorePoint>();
    }

    public IReadOnlyCollection<RestorePoint> BackupHistory => _backupHistory;

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        _backupHistory.Add(restorePoint);
    }
}