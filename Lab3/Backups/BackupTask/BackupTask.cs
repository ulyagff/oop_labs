using Backups.BackupObject;
using Backups.BackupsException;
using Backups.Path;
using Backups.Repository;
using Backups.Storage;
using Backups.StorageAlgorithm;

namespace Backups.BackupTask;

public class BackupTask : IBackupTask
{
    private readonly IStorageAlgorithm _storageAlgorithm;
    private readonly IRepository _repository;
    private readonly Archiver.Archiver _archiver;
    private List<BackupObject.BackupObject> _listBackupObjects;

    public BackupTask(IRepository repository, IStorageAlgorithm storageAlgorithm, Archiver.Archiver archiver, IPath archivePath)
    {
        _listBackupObjects = new List<BackupObject.BackupObject>();
        _storageAlgorithm = storageAlgorithm;
        _archiver = archiver;
        _repository = repository;
        Backup = new Backup();
        Time = DateTime.Now;
        Name = Time.ToString("yyyy-MM-dd-HH-mm-ss-ffff");
        ArchivePath = archivePath;
    }

    public Backup Backup { get; }
    public string Name { get; private set; }
    public IPath ArchivePath { get; }
    public DateTime Time { get; private set; }
    public IReadOnlyCollection<BackupObject.BackupObject> ListBackupObjects() => _listBackupObjects;

    public void AddBackupObject(BackupObject.BackupObject backupObject)
    {
        if (_listBackupObjects.Contains(backupObject))
            throw BackupTaskException.AlreadyHadBackupObject();
        _listBackupObjects.Add(backupObject);
    }

    public void RemoveBackupObject(BackupObject.BackupObject backupObject)
    {
        if (_listBackupObjects.Count == 0)
            throw BackupTaskException.EmptyContainerBackupObject();
        _listBackupObjects.Remove(backupObject);
    }

    public void Run()
    {
        Time = DateTime.Now;
        Name = Time.ToString("yyyy-MM-dd-HH-mm-ss-ffff");
        var fullPath = new Path.Path(ArchivePath.ConcatinatePath(Name));
        IStorage storage = _storageAlgorithm.Run(_listBackupObjects, _repository, _archiver, fullPath);
        Backup.AddRestorePoint(new RestorePoint(_listBackupObjects, storage, Time));
    }
}