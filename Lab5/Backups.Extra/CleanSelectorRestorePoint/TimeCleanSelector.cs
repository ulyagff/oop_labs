using Backups.BackupTask;

namespace Backups.Extra.CleanerRestorePoint;

public class TimeCleanSelector : ICleanSelector
{
    private readonly DateTime _criterion;

    public TimeCleanSelector(DateTime criterion)
    {
        _criterion = criterion;
    }

    public IReadOnlyCollection<RestorePoint> SelectObjects(IBackup backup)
    {
         return backup.BackupHistory
             .Where(i => DateTime.Compare(i.Time, _criterion) < 0)
             .ToList();
    }
}