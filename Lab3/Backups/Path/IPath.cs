namespace Backups.Path;

public interface IPath
{
    public string Name { get; }
    public string ToString();
    public string ConcatinatePath(IPath newPath);
    public string ConcatinatePath(string newPath);
}