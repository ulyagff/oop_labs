using Backups.Storage;

namespace Backups.BackupTask;

public class RestorePoint
{
    private readonly List<BackupObject.BackupObject> _listBackupObjects;

    public RestorePoint(List<BackupObject.BackupObject> listBackupObjects, IStorage storage, DateTime time)
    {
        _listBackupObjects = listBackupObjects;
        Storage = storage;
        Time = time;
    }

    public IStorage Storage { get; }
    public DateTime Time { get; }

    public IReadOnlyCollection<BackupObject.BackupObject> ListBackupObjects() => _listBackupObjects;
}