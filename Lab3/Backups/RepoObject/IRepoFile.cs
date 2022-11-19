using Backups.Visitor;

namespace Backups.RepoObject;

public interface IRepoFile : IRepoObject
{
       public Stream OpenStream();
}