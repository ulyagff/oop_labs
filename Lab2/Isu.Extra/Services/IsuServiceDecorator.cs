using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;
using Isu.Services;

namespace Isu.Extra.Services;

public class IsuServiceDecorator : IIsuServiceDecorator
{
    private readonly IIsuService _decoratee;
    private Dictionary<IsuIdentifier, ExtraStudent> _students;
    private Dictionary<GroupName, ExtraGroup> _groups;
    private List<ExtraStudy> _extraStudies;
    private List<MegaFaculty> _megaFaculties;

    public IsuServiceDecorator(IIsuService isuService)
    {
        _decoratee = isuService;
        _groups = new Dictionary<GroupName, ExtraGroup>();
        _students = new Dictionary<IsuIdentifier, ExtraStudent>();
        _extraStudies = new List<ExtraStudy>();
        _megaFaculties = new List<MegaFaculty>();
    }

    public MegaFaculty AddMegaFaculty(string name, List<FacultyName> listFaculty)
    {
        if (_megaFaculties
                .FirstOrDefault(i => i.MegaFacultyName == name) != null)
            throw IsuExtraServiceException.MegaFacultyIsContained();
        var newMegaFaculty = new MegaFaculty(name, listFaculty);
        _megaFaculties.Add(newMegaFaculty);
        return newMegaFaculty;
    }

    public MegaFaculty GetMegaFaculty(string name)
    {
        var megaFaculty = _megaFaculties
            .FirstOrDefault(i => i.MegaFacultyName == name);
        if (megaFaculty == null)
            throw MegaFacultyNameException.MegaFacultyIsAbsent(name);
        return megaFaculty;
    }

    public Group AddGroup(GroupName name)
    {
        Group newGroup = _decoratee.AddGroup(name);
        var groupMegafaculty = _megaFaculties
            .FirstOrDefault(i => i.ContainsFaculty(name.Faculty));
        _groups.Add(newGroup.Name, new ExtraGroup(newGroup, TimeTable.Empty(), groupMegafaculty));
        return newGroup;
    }

    public Student AddStudent(Group group, string name)
    {
        Student newStudent = _decoratee.AddStudent(group, name);
        _students.Add(newStudent.Id, new ExtraStudent(newStudent, _groups[group.Name]));
        return newStudent;
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        _decoratee.ChangeStudentGroup(student, newGroup);
        _students[student.Id].ExtraGroup = _groups[newGroup.Name];
    }

    public ExtraStudy AddExtraStudy(string name, MegaFaculty megaFaculty, List<ExtraStudyStream> streams)
    {
        if (_extraStudies
            .Any(i => i.MegaFaculty == megaFaculty))
            throw ExtraStudyException.ExtraStudyIsExist(megaFaculty);

        var newExtraStudy = new ExtraStudy(name, megaFaculty, streams);
        _extraStudies.Add(newExtraStudy);
        return newExtraStudy;
    }

    public void AddTimeTableToGroup(TimeTable timeTable, ExtraGroup extraGroup)
    {
        extraGroup.SetTimeTable(timeTable);
    }

    public void AddExtraStudyToStudent(ExtraStudent student, MegaFaculty megaFaculty)
    {
        if (megaFaculty == student.ExtraGroup.MegaFaculty)
            throw IsuExtraServiceException.MegaFacultiesAreSimilar(student.Student.Id);
        var extraStudy = _extraStudies
            .Where(i => i.MegaFaculty == megaFaculty)
            .ToList()
            .FirstOrDefault();
        if (extraStudy == null)
            throw IsuExtraServiceException.ExtraStudyIsAbsent();
        extraStudy.AddExtraStudyStreamToStudent(student);
    }

    public void DeleteExtraStudyStudent(ExtraStudent student)
    {
        ExtraStudyStream? extraStudyStream = student.ExtraStudyStream;
        if (extraStudyStream == null)
            throw ExtraStudentException.StudentHasNotExtraStudy();
        student.ExtraStudyStream = null;
        extraStudyStream.DeleteStudent(student);
    }

    public IReadOnlyCollection<ExtraStudyStream> GetStudyStreams(ExtraStudy extraStudy)
    {
        if (!_extraStudies.Contains(extraStudy))
            throw IsuExtraServiceException.ExtraStudyIsAbsent();
        return extraStudy.GetExtraStudyStreams();
    }

    public IReadOnlyCollection<ExtraStudent> GetStudentsOnStudyStream(ExtraStudyStream extraStudyStream)
    {
        return extraStudyStream.GetStudents();
    }

    public IReadOnlyCollection<ExtraStudent> StudentsWithoutExtraStudy(ExtraGroup group)
    {
        return group.Group.GiveStudents()
            .Select(i => _students[i.Id])
            .Where(i => i.ExtraStudyStream == null).ToList();
    }

    public IReadOnlyCollection<ExtraStudy> GetListExtraStudy()
    {
        return _extraStudies;
    }

    public Student GetStudent(IsuIdentifier id)
    {
        return _decoratee.GetStudent(id);
    }

    public Student? FindStudent(IsuIdentifier id)
    {
        return _decoratee.FindStudent(id);
    }

    public IReadOnlyCollection<Student> FindStudents(GroupName groupName)
    {
        return _decoratee.FindStudents(groupName);
    }

    public IReadOnlyCollection<Student> FindStudents(CourseNumber courseNumber)
    {
        return _decoratee.FindStudents(courseNumber);
    }

    public Group? FindGroup(GroupName groupName)
    {
        return _decoratee.FindGroup(groupName);
    }

    public ExtraGroup GetExtraGroup(GroupName groupName)
    {
        if (!_groups.ContainsKey(groupName))
            throw IsuExtraServiceException.ExtraGroupIsMissing(groupName);
        return _groups[groupName];
    }

    public ExtraStudent GetExtraStudent(IsuIdentifier id)
    {
        if (!_students.ContainsKey(id))
            throw IsuExtraServiceException.ExtraStudentIsMissing(id);
        return _students[id];
    }

    public IReadOnlyCollection<Group> FindGroups(CourseNumber courseNumber)
    {
        return _decoratee.FindGroups(courseNumber);
    }
}