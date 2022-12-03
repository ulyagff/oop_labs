using Backups.BackupTask;
using Backups.Extra.Visitor;
using Backups.Repository;
using Backups.Visitor;

namespace Backups.Extra.Recovery;

public class RecoveryToOrigin : IRecovery
{
    private IRepository _repository;

    public RecoveryToOrigin(IRepository repository)
    {
        _repository = repository;
    }

    public void MakeRecovery(RestorePoint restorePoint)
    {
        IVisitor visitor = new RecoverVisitor(_repository);
        foreach (var repoObject in restorePoint.Storage.ReturnRepoObjects())
        {
            repoObject.Accept(visitor);
        }

        restorePoint.Storage.ReturnRepoObjects();
    }
}