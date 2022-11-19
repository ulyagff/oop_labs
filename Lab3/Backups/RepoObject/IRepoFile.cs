using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoFile : IRepoObject
{
       public Func<Stream> OpenStream { get; }
}