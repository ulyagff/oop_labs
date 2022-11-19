using Backups.RepoObject;

namespace Backups.Storage;

public interface IStorage
{
    public IReadOnlyCollection<IRepoObject> ReturnRepoObjects();
}
