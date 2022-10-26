using Isu.Models;
namespace Isu.Extra.Entities;

public class Lecturer
{
    public Lecturer(string? name)
    {
        Id = new IsuIdentifier();
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
    }

    public IsuIdentifier Id { get; }
    public string Name { get; }
}