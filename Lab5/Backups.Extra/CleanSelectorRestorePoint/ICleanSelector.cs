using Backups.BackupTask;

namespace Backups.Extra.CleanerRestorePoint;

public interface ICleanSelector
{
    public IReadOnlyCollection<RestorePoint> SelectObjects(IBackup backup);
}