namespace Backups.BackupsException;

public class BackupTaskException : BackupException
{
    private BackupTaskException(string message) { }

    public static BackupTaskException AlreadyHadBackupObject()
    {
        return new BackupTaskException("Backup Task already have this backup object");
    }

    public static BackupTaskException EmptyContainerBackupObject()
    {
        return new BackupTaskException("Backup Task doesnt have backup objects");
    }
}