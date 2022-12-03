using Backups.RepoObject;
using Backups.Repository;
using Backups.Visitor;

namespace Backups.Extra.Visitor;

public class RecoverVisitor : IVisitor
{
    private IRepository _repository;

    public RecoverVisitor(IRepository repository)
    {
        _repository = repository;
    }

    public void Visit(IRepoFile file)
    {
        using Stream temp = _repository.OpenWrite(file.Name);
        file.OpenStream().CopyTo(temp);
    }

    public void Visit(IRepoFolder folder)
    {
        foreach (var folderObject in folder.Objects())
        {
            folderObject.Accept(this);
        }
    }
}