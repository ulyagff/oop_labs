using System.Collections.ObjectModel;
using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(GroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(IsuIdentifier id);
    Student? FindStudent(IsuIdentifier id);
    IReadOnlyCollection<Student> FindStudents(GroupName groupName);
    IReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber);

    Group? FindGroup(GroupName groupName);
    IReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}