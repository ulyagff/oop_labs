using Backups.BackupObject;
using Backups.Repository;
using Backups.StorageAlgorithm;

namespace Backups.BackupTask;

public class BackupTask
{
    private List<BackupObject.BackupObject> _listBackupObjects;
    private IStorageAlgorithm _storageAlgorithm;
    private IRepository _repository;
    private Archiver.Archiver _archiver;
    private Backup _backup;
    public BackupTask(string name, IRepository repository, IStorageAlgorithm storageAlgorithm, Archiver.Archiver archiver)
    {
        _listBackupObjects = new List<BackupObject.BackupObject>(); // TODO: validation
        _storageAlgorithm = storageAlgorithm;
        _archiver = archiver;
        _repository = repository;
        _backup = new Backup();
        Time = DateTime.Now;
        Name = Time.ToString("yyyy-MM-dd");
    }

    public string Name { get; }
    public DateTime Time { get; }

    public void AddBackupObject(BackupObject.BackupObject backupObject)
    {
        _listBackupObjects.Add(backupObject); // TODO: validation
    }

    public void RemoveBackupObject(BackupObject.BackupObject backupObject)
    {
        _listBackupObjects.Remove(backupObject); // TODO: validation
    }

    public void Run()
    {
        _backup.AddRestorePoint(new RestorePoint(_listBackupObjects, _storageAlgorithm.Run(_listBackupObjects, _repository, _archiver, Name), Time));
    }
}