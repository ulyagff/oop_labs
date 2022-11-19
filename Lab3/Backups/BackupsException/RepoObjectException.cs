namespace Backups.BackupsException;

public class RepoObjectException : BackupException
{
    private RepoObjectException(string message) { }

    public static RepoObjectException ExpectedRepoFile()
    {
        return new RepoObjectException("Repository mast to return RepoFile");
    }
}