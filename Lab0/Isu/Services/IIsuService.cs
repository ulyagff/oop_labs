using System.Collections.ObjectModel;
using Isu.Entities;
using Isu.Models;

namespace Isu.Services;

public interface IIsuService
{
    Group AddGroup(GroupName name);
    Student AddStudent(Group group, string name);

    Student GetStudent(int id);
    Student? FindStudent(int id);
    ReadOnlyCollection<Student> FindStudents(GroupName groupName);
    ReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber);

    Group? FindGroup(GroupName groupName);
    ReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber);

    void ChangeStudentGroup(Student student, Group newGroup);
}