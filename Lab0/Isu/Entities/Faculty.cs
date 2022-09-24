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
        if (_groups.ContainsKey(newGroup.Name))
            throw GroupExceptionFactory.FacultyIsContainsGroup(FacultyLetter.Letter, newGroup.Name.GroupNameStr);
        if (newGroup.Name.Faculty != FacultyLetter)
            throw GroupExceptionFactory.FacultyIsNotContainGroup(FacultyLetter.Letter, newGroup.Name.GroupNameStr);
        _groups.Add(newGroup.Name, newGroup);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }
}