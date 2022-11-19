using Backups.RepoObject;

namespace Backups.Repository;

public interface IRepository
{
    public Stream OpenWrite(string path);
    public IRepoObject ReturnRepoObject(string key);
}