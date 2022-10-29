using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Isu.Services;
using Xunit;
namespace Isu.Extra.Test;

public class TestStudentAndExtraStudy
{
    private Isu.Services.IsuService _isuService;
    private IsuServiceDecorator _isuExtraService;
    private List<ExtraStudyStream> _streams;
    private ExtraStudent _newExtraStudent;
    private ExtraStudy _newExtraStudy;
    private ExtraGroup _newGroup;

    public TestStudentAndExtraStudy()
    {
        _isuService = new IsuService();
        _isuExtraService = new IsuServiceDecorator(_isuService);
        _isuExtraService.AddMegaFaculty("CTaM", new List<FacultyName>()
        {
            new FacultyName('N'),
            new FacultyName('D'),
            new FacultyName('K'),
            new FacultyName('P'),
        });
        _isuExtraService.AddMegaFaculty("TInT", new List<FacultyName>()
        {
            new FacultyName('M'),
        });

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security", DayOfWeek.Monday);
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security", DayOfWeek.Monday);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddStudyClass(class1);
        builderMon.AddStudyClass(class2);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security", DayOfWeek.Wednesday);
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security", DayOfWeek.Wednesday);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddStudyClass(class3);
        builderWed.AddStudyClass(class4);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, _isuExtraService.GetMegaFaculty("TInT"), timeTable1);

        _streams = new List<ExtraStudyStream>();
        _streams.Add(stream1);

        GroupName groupName = new GroupName("N3105");
        Group newGroup = _isuExtraService.AddGroup(groupName);
        _newGroup = _isuExtraService.GetExtraGroup(groupName);
        Student newStudent = _isuExtraService.AddStudent(newGroup, "Ivan Ivanov");
        _newExtraStudent = _isuExtraService.GetExtraStudent(newStudent.Id);

        StudyClass class5 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 7, "666", "oop", DayOfWeek.Monday);
        StudyClass class6 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 8, "666", "oop", DayOfWeek.Monday);
        TimeTable.TimeTableBuilder builderMon2 = new TimeTable.TimeTableBuilder();
        builderMon2.AddStudyClass(class5);
        builderMon2.AddStudyClass(class6);
        var timeTable3 = builderMon2.Build();
        _isuExtraService.AddTimeTableToGroup(timeTable3, _newExtraStudent.ExtraGroup);
        _newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", _isuExtraService.GetMegaFaculty("TInT"), _streams);
    }

    [Fact]
    public void AddExtraStudyToStudent()
    {
        _isuExtraService.AddExtraStudyToStudent(_newExtraStudent, _isuExtraService.GetMegaFaculty("TInT"));
        Assert.Equal(_newExtraStudent.ExtraStudyStream, _streams.FirstOrDefault());
    }

    [Fact]
    public void DeleteExtraStudyStudent()
    {
        _isuExtraService.AddExtraStudyToStudent(_newExtraStudent, _isuExtraService.GetMegaFaculty("TInT"));
        _isuExtraService.DeleteExtraStudyStudent(_newExtraStudent);
        Assert.Null(_newExtraStudent.ExtraStudyStream);
    }

    [Fact]
    public void GetExtraStudyStream()
    {
        IReadOnlyCollection<ExtraStudyStream> actualListStreams = _isuExtraService.GetStudyStreams(_newExtraStudy);
        Assert.Equal(_streams, actualListStreams);
    }

    [Fact]
    public void GetStudentsFromExtraStudyStream()
    {
        Student newStudent1 = _isuExtraService.AddStudent(_newGroup.Group, "Suren Ivanov");
        Student newStudent2 = _isuExtraService.AddStudent(_newGroup.Group, "Liza Ivanova");

        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(_newExtraStudent.Student.Id), _isuExtraService.GetMegaFaculty("TInT"));
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent1.Id), _isuExtraService.GetMegaFaculty("TInT"));
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent2.Id), _isuExtraService.GetMegaFaculty("TInT"));

        IReadOnlyCollection<ExtraStudent> actualListStudents = new List<ExtraStudent>()
        {
            _newExtraStudent,
            _isuExtraService.GetExtraStudent(newStudent1.Id),
            _isuExtraService.GetExtraStudent(newStudent2.Id),
        };

        Assert.Equal(_isuExtraService.GetStudentsOnStudyStream(_streams[0]), actualListStudents);
    }

    [Fact]
    public void GetStudentsWithoutExtraStudyStream()
    {
        Student newStudent1 = _isuExtraService.AddStudent(_newGroup.Group, "Suren Ivanov");
        Student newStudent2 = _isuExtraService.AddStudent(_newGroup.Group, "Liza Ivanova");

        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(_newExtraStudent.Student.Id), _isuExtraService.GetMegaFaculty("TInT"));

        IReadOnlyCollection<ExtraStudent> actualListStudents = new List<ExtraStudent>()
        {
            _isuExtraService.GetExtraStudent(newStudent1.Id),
            _isuExtraService.GetExtraStudent(newStudent2.Id),
        };

        Assert.Equal(_isuExtraService.StudentsWithoutExtraStudy(_newGroup), actualListStudents);
    }
}