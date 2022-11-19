using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoFolder : IRepoObject
{
    public Func<IReadOnlyCollection<IRepoObject>> Objects { get; }
}