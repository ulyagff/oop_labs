using System.IO.Compression;
using Backups.Path;
using Backups.RepoObject;
using Backups.Repository;

namespace Backups.ZipObject;

public class ZipFolder : IZipObject
{
    private List<IZipObject> _listZipObjects;
    public ZipFolder(IPath name, List<ZipObject.IZipObject> listZipObjects)
    {
        NameRepo = name;
        NameZip = new Path.Path($"{name.Name}.zip");
        _listZipObjects = listZipObjects;
    }

    public IPath NameRepo { get; }
    public IPath NameZip { get; }

    public IReadOnlyCollection<IZipObject> ListZipObjects() => _listZipObjects;

    public IRepoObject ReturnRepoObject(ZipArchiveEntry entry)
    {
        return new RepoFolder(() => FolderObjects(entry), NameRepo);
    }

    private IReadOnlyCollection<IRepoObject> FolderObjects(ZipArchiveEntry entry)
    {
        using ZipArchive folder = new ZipArchive(entry.Open(), ZipArchiveMode.Read);

        return folder.Entries
            .Select(folderEntry => _listZipObjects
            .Single(i => i.NameZip.Name == folderEntry.Name)
            .ReturnRepoObject(folderEntry))
            .ToList();
    }
}