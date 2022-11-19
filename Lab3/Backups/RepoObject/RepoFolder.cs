using Backups.Visitor;

namespace Backups.RepoObject;

public class RepoFolder : IRepoFolder
{
 public RepoFolder(Func<IReadOnlyCollection<IRepoObject>> objects, string name)
 {
     Objects = objects;
     Name = name;
 }

 public string Name { get; }
 public Func<IReadOnlyCollection<IRepoObject>> Objects { get; }

 public void Accept(IVisitor visitor)
 {
     visitor.Visit(this);
 }
}