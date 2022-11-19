namespace Backups.BackupTask;

public class Backup
{
    private List<RestorePoint> _backupHistory;

    public Backup()
    {
        _backupHistory = new List<RestorePoint>();
    }

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        _backupHistory.Add(restorePoint);
    }
}