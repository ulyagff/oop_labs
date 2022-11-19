using Backups.Path;
using Backups.Visitor;

namespace Backups.RepoObject;

public class RepoFolder : IRepoFolder
{
    private Func<IReadOnlyCollection<IRepoObject>> _funcObjects;
    public RepoFolder(Func<IReadOnlyCollection<IRepoObject>> objects, IPath name)
    {
        _funcObjects = objects;
        Name = name;
    }

    public IPath Name { get; }

    public IReadOnlyCollection<IRepoObject> Objects()
    {
        return _funcObjects();
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}