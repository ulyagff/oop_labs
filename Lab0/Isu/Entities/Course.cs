using System.Collections.ObjectModel;
using Isu.CustomException;
using Isu.Models;

namespace Isu.Entities;

public class Course
{
    private Dictionary<GroupName, Group> _groups;

    public Course(CourseNumber courseNumber)
    {
        NumberOfCourse = courseNumber;
        _groups = new Dictionary<GroupName, Group>();
    }

    public CourseNumber NumberOfCourse { get; }

    public void AddGroup(Group newGroup)
    {
        if (_groups.ContainsKey(newGroup.NameOfGroup))
            throw StereotypeIsuException.CourseIsContainsGroup(NumberOfCourse.NumberOfCourse, newGroup.NameOfGroup.GroupNameStr);
        if (newGroup.NameOfGroup.NumberOfCourse != NumberOfCourse)
            throw StereotypeIsuException.CourseIsNotContainGroup(NumberOfCourse.NumberOfCourse, newGroup.NameOfGroup.GroupNameStr);
        _groups.Add(newGroup.NameOfGroup, newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }

    public ReadOnlyCollection<Group> GiveGroups()
    {
        List<Group> dictionaryToList = new List<Group>(_groups.Count);
        foreach (var group in _groups)
            dictionaryToList.Add(group.Value);
        ReadOnlyCollection<Group> readOnlyList = dictionaryToList.AsReadOnly();
        return readOnlyList;
    }
}