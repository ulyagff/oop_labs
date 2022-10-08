using Isu.Models;
namespace Isu.Entities;

public class Student : IEquatable<Student>
{
    public Student(string? name, Group? group)
    {
        Id = new IsuIdentifier();
        if (name == null) throw new ArgumentNullException("name");
        else Name = name;
        if (group == null) throw new ArgumentNullException("group");
        else Group = group;
    }

    public IsuIdentifier Id { get; }
    public string Name { get; }
    public Group Group { get; private set; }

    public void ChangeGroup(Group newGroup)
    {
        Group.DeleteStudent(this);
        newGroup.AddStudent(this);
        Group = newGroup;
    }

    public bool Equals(Student? other)
    {
        if (other == null)
            return false;

        if (this.Id.Equals(other.Id))
            return true;
        return false;
    }
}