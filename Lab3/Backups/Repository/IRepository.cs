using Backups.Path;
using Backups.RepoObject;

namespace Backups.Repository;

public interface IRepository
{
    public Stream OpenWrite(IPath path);
    public IRepoObject ReturnRepoObject(IPath key);
}