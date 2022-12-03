using Backups.BackupTask;

namespace Backups.Extra.Recovery;

public interface IRecovery
{
    public void MakeRecovery(RestorePoint restorePoint);
}