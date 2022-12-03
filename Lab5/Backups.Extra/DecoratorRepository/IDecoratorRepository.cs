using Backups.RepoObject;
using Backups.Repository;

namespace Backups.Extra.DecoratorRepository;

public interface IDecoratorRepository : IRepository
{
    public void DeleteRepoObject(IRepoObject repoObject);
    public void MoveRepoObject(IRepoObject oldRepoObject, IRepoObject newRepoObject);
}