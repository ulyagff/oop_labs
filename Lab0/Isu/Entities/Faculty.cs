using Isu.CustomException;
using Isu.Models;

namespace Isu.Entities;

public class Faculty
{
    private Dictionary<GroupName, Group> _groups;

    public Faculty(FacultyName facultyName)
    {
        FacultyLetter = facultyName;
        _groups = new Dictionary<GroupName, Group>();
    }

    public FacultyName FacultyLetter { get; }

    public void AddGroup(Group newGroup)
    {
        if (_groups.ContainsKey(newGroup.NameOfGroup))
            throw StereotypeIsuException.FacultyIsContainsGroup(FacultyLetter.Letter, newGroup.NameOfGroup.GroupNameStr);
        if (newGroup.NameOfGroup.Faculty != FacultyLetter)
            throw StereotypeIsuException.FacultyIsNotContainGroup(FacultyLetter.Letter, newGroup.NameOfGroup.GroupNameStr);
        _groups.Add(newGroup.NameOfGroup, newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }
}