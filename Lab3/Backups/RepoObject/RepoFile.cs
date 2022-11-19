using Backups.Visitor;

namespace Backups.RepoObject;

public class RepoFile : IRepoFile
{
    public RepoFile(Func<Stream> openStream, string name)
    {
        Name = name;
        OpenStream = openStream;
    }

    public string Name { get; }
    public Func<Stream> OpenStream { get; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}