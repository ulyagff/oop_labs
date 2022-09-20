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
        NameOfGroup = groupName;
    }

    public GroupName NameOfGroup { get; init; }

    public void AddStudent(Student newStudent)
    {
        if (_students.ContainsKey(newStudent.Id))
            throw StereotypeIsuException.GroupIsContainsStudent(newStudent.Id);
        if (_students.Count == MaxGroupSize)
            throw StereotypeIsuException.MaxSizeGroup(MaxGroupSize);
        _students.Add(newStudent.Id, newStudent);
    }

    public void DeleteStudent(int id)
    {
        if (!_students.ContainsKey(id))
            throw StereotypeIsuException.StudentIsMissingInGroup(id, NameOfGroup.GroupNameStr);
        if (_students.Count == MinGroupSize)
            throw StereotypeIsuException.MinSizeGroup(MinGroupSize);
        _students.Remove(id);
    }

    public Student? FindStudent(int id)
    {
        return _students.ContainsKey(id) ? _students[id] : null;
    }

    public ReadOnlyCollection<Student> GiveStudents()
    {
        List<Student> dictionaryToList = new List<Student>(_students.Count);
        foreach (var student in _students)
            dictionaryToList.Add(student.Value);
        ReadOnlyCollection<Student> readOnlyList = dictionaryToList.AsReadOnly();
        return readOnlyList;
    }
}
