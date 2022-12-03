using Backups.BackupTask;
using Backups.Extra.Visitor;
using Backups.Repository;
using Backups.Visitor;

namespace Backups.Extra.Recovery;

public class RecoveryToAnother : IRecovery
{
    private IRepository _repository;

    public RecoveryToAnother(IRepository repository)
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