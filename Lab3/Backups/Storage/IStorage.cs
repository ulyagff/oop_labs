using Backups.RepoObject;

namespace Backups.Storage;

public interface IStorage
{
    public List<IRepoObject> ReturnRepoObjects();
}
