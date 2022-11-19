using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoObject
{
    public string Name { get; }
    public void Accept(IVisitor visitor);
}