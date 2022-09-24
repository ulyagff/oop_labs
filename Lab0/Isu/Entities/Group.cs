using System.Collections.ObjectModel;
using Isu.CustomException;
using Isu.Models;
namespace Isu.Entities;

public class Group
{
    public const int MaxGroupSize = 30;
    public const int MinGroupSize = 0;
    private Dictionary<int, Student> _students;
    public Group(GroupName groupName)
    {
        _students = new Dictionary<int, Student>();
        Name = groupName;
    }

    public GroupName Name { get; init; }

    public void AddStudent(Student newStudent)
    {
        if (_students.ContainsKey(newStudent.Id))
            throw GroupExceptionFactory.GroupIsContainsStudent(newStudent.Id);
        if (_students.Count == MaxGroupSize)
            throw GroupExceptionFactory.MaxSizeGroup(MaxGroupSize);
        _students.Add(newStudent.Id, newStudent);
    }

    public void DeleteStudent(int id)
    {
        if (_students.Count == MinGroupSize)
            throw GroupExceptionFactory.MinSizeGroup(MinGroupSize);
        if (!_students.ContainsKey(id))
            throw GroupExceptionFactory.StudentIsMissingInGroup(id, Name.GroupNameStr);
        _students.Remove(id);
    }

    public Student? FindStudent(int id)
    {
        return _students.ContainsKey(id) ? _students[id] : null;
    }

    public ReadOnlyCollection<Student> GiveStudents()
    {
        List<Student> dictionaryToList = _students.Values.ToList();
        ReadOnlyCollection<Student> readOnlyList = dictionaryToList.AsReadOnly();
        return readOnlyList;
    }
}
