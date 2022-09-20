namespace Isu.Entities;

public class Student
{
    private static int _newId = 1;
    public Student(string? name, Group? group)
    {
        Id = _newId++;
        if (name == null) throw new NullReferenceException();
        else Name = name;
        if (group == null) throw new NullReferenceException();
        else Group = group;
    }

    public int Id { get; init; }
    public string Name { get; }
    public Group Group { get; private set; }

    public void ChangeGroup(Group newGroup)
    {
        Group.DeleteStudent(Id);
        newGroup.AddStudent(this);
        Group = newGroup;
    }
}