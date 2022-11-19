using Backups.Storage;

namespace Backups.BackupTask;

public class RestorePoint
{
    private List<BackupObject.BackupObject> _listBackupObjects;
    private IStorage _storage;
    private DateTime _time;

    public RestorePoint(List<BackupObject.BackupObject> listBackupObjects, IStorage storage, DateTime time)
    {
        _listBackupObjects = listBackupObjects;
        _storage = storage;
        _time = time;
    }
}