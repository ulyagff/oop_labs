namespace Backups.BackupsException;

public class BackupException : Exception
{
    public BackupException()
        : base() { }
    public BackupException(string message)
        : base(message) { }
}