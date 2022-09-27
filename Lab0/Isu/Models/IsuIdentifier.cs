namespace Isu.Models;

public class IsuIdentifier : IEquatable<IsuIdentifier>
{
    public const int MinIsuNumber = 100000;
    public const int MaxIsuNumber = 999999;
    private static int _newId = MinIsuNumber;

    public IsuIdentifier()
    {
        if (_newId == MaxIsuNumber)
            _newId = MinIsuNumber;
        Id = _newId++;
    }

    public int Id { get; }

    public bool Equals(IsuIdentifier? other)
    {
        if (other == null)
            return false;
        if (this.Id == other.Id)
            return true;
        return false;
    }
}