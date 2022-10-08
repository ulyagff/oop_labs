using System.Collections.ObjectModel;
using Isu.CustomException;
using Isu.Entities;
using Isu.Models;
namespace Isu.Services;

public class IsuService : IIsuService
{
    private Dictionary<IsuIdentifier, Student> _students;
    private Dictionary<GroupName, Group> _groups;
    private Dictionary<FacultyName, Faculty> _faculties;
    private Dictionary<CourseNumber, Course> _courses;

    public IsuService()
    {
        _students = new Dictionary<IsuIdentifier, Student>();
        _groups = new Dictionary<GroupName, Group>();
        _faculties = new Dictionary<FacultyName, Faculty>();
        _courses = new Dictionary<CourseNumber, Course>();
    }

    public Group AddGroup(GroupName name)
    {
        if (!_faculties.ContainsKey(name.Faculty))
        {
            Faculty newFaculty = new Faculty(name.Faculty);
            _faculties.Add(newFaculty.FacultyLetter, newFaculty);
        }

        if (!_courses.ContainsKey(name.NumberOfCourse))
        {
            Course newCourse = new Course(name.NumberOfCourse);
            _courses.Add(newCourse.NumberOfCourse, newCourse);
        }

        Group newGroup = new Group(name);
        _courses[newGroup.Name.NumberOfCourse].AddGroup(newGroup);
        _faculties[newGroup.Name.Faculty].AddGroup(newGroup);
        _groups.Add(newGroup.Name, newGroup);
        return newGroup;
    }

    public Student AddStudent(Group group, string name)
    {
        if (!_groups.ContainsValue(group))
            throw IsuServiseException.GroupIsMissing(group.Name.GroupNameStr);
        Student newStudent = new Student(name, group);
        if (_students.ContainsKey(newStudent.Id))
            _students.Remove(newStudent.Id);
        group.AddStudent(newStudent);
        _students.Add(newStudent.Id, newStudent);
        return newStudent;
    }

    public Student GetStudent(IsuIdentifier id)
    {
        if (!_students.ContainsKey(id))
            throw IsuServiseException.StudentIsMissing(id.Id);
        return _students[id];
    }

    public Student? FindStudent(IsuIdentifier id)
    {
        return _students.ContainsKey(id) ? _students[id] : null;
    }

    public IReadOnlyCollection<Student> FindStudents(GroupName groupName)
    {
        if (this.FindGroup(groupName) == null)
            throw IsuServiseException.GroupIsMissing(groupName.GroupNameStr);
        return _groups[groupName].GiveStudents();
    }

    public IReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber)
    => _courses[courseNumber].
            GiveGroups().
            SelectMany(x => x.GiveStudents()).
            ToList();

    public Group? FindGroup(GroupName groupName)
    {
        return _groups.ContainsKey(groupName) ? _groups[groupName] : null;
    }

    public IReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber)
    {
        if (!_courses.ContainsKey(courseNumber))
            throw IsuServiseException.CourseIsMissing(courseNumber.NumberOfCourse);
        return _courses[courseNumber].GiveGroups();
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        student.ChangeGroup(newGroup);
    }
}