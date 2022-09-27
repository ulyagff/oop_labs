using System.Collections.ObjectModel;
using Isu.CustomException;
using Isu.Models;
namespace Isu.Entities;

public class Group
{
    public const int MaxGroupSize = 30;
    public const int MinGroupSize = 0;
    private HashSet<Student> _students;
    public Group(GroupName groupName)
    {
        _students = new HashSet<Student>();
        Name = groupName;
    }

    public GroupName Name { get; init; }

    public void AddStudent(Student newStudent)
    {
        if (_students.Contains(newStudent))
            throw GroupException.GroupIsContainsStudent(newStudent.Id.Id);
        if (_students.Count == MaxGroupSize)
            throw GroupException.MaxSizeGroup(MaxGroupSize);
        _students.Add(newStudent);
    }

    public void DeleteStudent(Student newStudent)
    {
        if (_students.Count == MinGroupSize)
            throw GroupException.MinSizeGroup(MinGroupSize);
        if (!_students.Contains(newStudent))
            throw GroupException.StudentIsMissingInGroup(newStudent.Id.Id, Name.GroupNameStr);
        _students.Remove(newStudent);
    }

    public IReadOnlyList<Student> GiveStudents()
    {
        return _students.ToList();
    }
}
