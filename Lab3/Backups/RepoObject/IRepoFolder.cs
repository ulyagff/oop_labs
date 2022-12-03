using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoFolder : IRepoObject
{
    public IReadOnlyCollection<IRepoObject> Objects();
}