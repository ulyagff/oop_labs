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
        if (_groups.ContainsKey(newGroup.Name))
            throw GroupException.CourseIsContainsGroup(NumberOfCourse.NumberOfCourse, newGroup.Name.GroupNameStr);
        if (newGroup.Name.NumberOfCourse != NumberOfCourse)
            throw GroupException.CourseIsNotContainGroup(NumberOfCourse.NumberOfCourse, newGroup.Name.GroupNameStr);
        _groups.Add(newGroup.Name, newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }

    public IReadOnlyCollection<Group> GiveGroups()
    {
        return _groups.Values.ToList();
    }
}