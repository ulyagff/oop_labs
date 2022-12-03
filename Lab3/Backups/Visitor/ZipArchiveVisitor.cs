using System.IO.Compression;
using Backups.Path;
using Backups.RepoObject;
using Backups.ZipObject;

namespace Backups.Visitor;

public class ZipArchiveVisitor : IVisitor
{
    private Stack<ZipArchive> _archives;
    private Stack<List<IZipObject>> _listsZipObjects;

    public ZipArchiveVisitor(ZipArchive archive)
    {
        _archives = new Stack<ZipArchive>();
        _listsZipObjects = new Stack<List<IZipObject>>();
        _listsZipObjects.Push(new List<IZipObject>());
        _archives.Push(archive);
    }

    public ZipFolder FinalZipObject(IPath name)
    {
        return new ZipFolder(name, _listsZipObjects.Peek());
    }

    public void Visit(IRepoFile file)
    {
        ZipArchiveEntry entry = _archives.Peek().CreateEntry($"{file.Name.Name}.zip");
        using Stream fileStream = entry.Open();
        file.OpenStream().CopyTo(fileStream);
        _listsZipObjects.Peek().Add(new ZipObject.ZipFile(file.Name));
    }

    public void Visit(IRepoFolder folder)
    {
        ZipArchiveEntry entry = _archives.Peek().CreateEntry($"{folder.Name.Name}.zip");
        using Stream entryStream = entry.Open();
        using var archive = new ZipArchive(entryStream);
        _archives.Push(archive);
        _listsZipObjects.Push(new List<IZipObject>());
        foreach (var folderObject in folder.Objects())
        {
            folderObject.Accept(this);
        }

        var newList = _listsZipObjects.Pop();
        _listsZipObjects.Peek().Add(new ZipFolder(folder.Name, newList));
        _archives.Pop();
    }
}