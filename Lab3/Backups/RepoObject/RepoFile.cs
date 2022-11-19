using Backups.Path;
using Backups.Visitor;

namespace Backups.RepoObject;

public class RepoFile : IRepoFile
{
    private Func<Stream> _funcOpenStream;

    public RepoFile(Func<Stream> openStream, IPath name)
    {
        Name = name;
        _funcOpenStream = openStream;
    }

    public IPath Name { get; }

    public Stream OpenStream()
    {
        return _funcOpenStream();
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}