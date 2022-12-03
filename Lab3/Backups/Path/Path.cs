namespace Backups.Path;

public class Path : IPath
{
    private List<string> _elementPath;

    public Path(List<string> elementPath)
    {
        _elementPath = elementPath;
        Name = _elementPath.Last();
    }

    public Path(string elementPath)
    {
        _elementPath = elementPath.Split(System.IO.Path.AltDirectorySeparatorChar).ToList();
        Name = _elementPath.Last();
    }

    public IReadOnlyCollection<string> ElementPath => _elementPath;

    public string Name { get; private set; }

    public override string ToString()
    {
        string fullPath = string.Join(System.IO.Path.AltDirectorySeparatorChar.ToString(), _elementPath);
        fullPath = System.IO.Path.AltDirectorySeparatorChar.ToString() + fullPath;
        return fullPath;
    }

    public string ConcatinatePath(IPath newPath)
    {
        var copyBasePath = new Path(this.ToString());
        var elementPath = newPath
            .ToString()
            .Split(System.IO.Path.AltDirectorySeparatorChar).ToList();
        elementPath.Remove(elementPath.First());
        copyBasePath._elementPath.AddRange(elementPath);
        copyBasePath.Name = _elementPath.Last();
        return copyBasePath.ToString();
    }

    public string ConcatinatePath(string newPath)
    {
        var copyBasePath = new Path(this.ToString());
        var elementPath = newPath
            .Split(System.IO.Path.AltDirectorySeparatorChar).ToList();
        copyBasePath._elementPath.AddRange(elementPath);
        copyBasePath.Name = _elementPath.Last();

        return copyBasePath.ToString();
    }
}