using Backups.BackupTask;

namespace Backups.Extra.CleanerRestorePoint;

public class CountCleanSelector : ICleanSelector
{
    private int _restorePointCount;

    public CountCleanSelector(int restorePointCount)
    {
        _restorePointCount = restorePointCount;
    }

    public IReadOnlyCollection<RestorePoint> SelectObjects(IBackup backup)
    {
        int countExtraElement = backup.BackupHistory.Count - _restorePointCount;
        if (countExtraElement > 0)
        {
            return backup.BackupHistory.Take(countExtraElement).ToList();
        }

        return new List<RestorePoint>();
    }
}