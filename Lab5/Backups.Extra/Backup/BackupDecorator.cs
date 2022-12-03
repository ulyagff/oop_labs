using Backups.BackupTask;

namespace Backups.Extra.BackupDecorator;

public class BackupDecorator : IBackupDecorator
{
    private IBackup _decoratee;
    private List<RestorePoint> _deletedPoints;

    public BackupDecorator(IBackup decoratee, IReadOnlyCollection<RestorePoint> backupHistory)
    {
        _decoratee = decoratee;
        _deletedPoints = new List<RestorePoint>();
    }

    public IReadOnlyCollection<RestorePoint> BackupHistory
    {
        get
        {
            var result = new List<RestorePoint>(_decoratee.BackupHistory);
            return result.Except(_deletedPoints).ToList();
        }
    }

    public void AddRestorePoint(RestorePoint restorePoint)
    {
        _decoratee.AddRestorePoint(restorePoint);
    }

    public void DeleteRestorePoint(RestorePoint restorePoint)
    {
        _deletedPoints.Add(restorePoint);
    }
}