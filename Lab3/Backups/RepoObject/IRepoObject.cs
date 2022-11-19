using Backups.Path;
using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoObject
{
    public IPath Name { get; }
    public void Accept(IVisitor visitor);
}