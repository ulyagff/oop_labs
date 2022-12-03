namespace Backups.Extra.BackupExtraException;

public class BackupExtraException : Exception
{
    public BackupExtraException()
        : base() { }
    public BackupExtraException(string message)
        : base(message) { }
}