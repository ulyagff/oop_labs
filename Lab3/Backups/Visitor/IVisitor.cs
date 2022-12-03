using Backups.RepoObject;

namespace Backups.Visitor;

public interface IVisitor
{
    void Visit(IRepoFile file);
    void Visit(IRepoFolder folder);
}