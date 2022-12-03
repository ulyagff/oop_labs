namespace Backups.Extra.BackupExtraException;

public class RepositoryExtraException : BackupExtraException
{
    private RepositoryExtraException(string message) { }

    public static RepositoryExtraException MoveObjectToFile()
    {
        return new RepositoryExtraException("Backup object can be moved only to directory");
    }
}