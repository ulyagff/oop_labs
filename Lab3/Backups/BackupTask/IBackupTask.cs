namespace Backups.BackupTask;

public interface IBackupTask
{
    public void AddBackupObject(BackupObject.BackupObject backupObject);
    public void RemoveBackupObject(BackupObject.BackupObject backupObject);
    public void Run();
}