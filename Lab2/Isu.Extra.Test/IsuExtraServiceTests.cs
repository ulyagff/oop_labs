using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Extra.Services;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Extra.Test;

public class IsuExtraServiceTests
{
    private Isu.Services.IsuService _isuService;
    private IsuServiceDecorator _isuExtraService;

    public IsuExtraServiceTests()
    {
        _isuService = new IsuService();
        _isuExtraService = new IsuServiceDecorator(_isuService);
    }

    [Fact]
    public void AddNewExtraStudy()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");
        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);

        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);

        Assert.Contains(newExtraStudy, _isuExtraService.GetListExtraStudy());
    }

    [Fact]
    public void AddExtraStudyToStudent()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");
        MegaFacultyName ctamMegaFaculty = new MegaFacultyName("CTaM");

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes1 = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes1);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security");
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security");
        StudyClass?[] classes2 = new[] { class3, null, class4, null, null, null, null, null };
        Day wednesday = new Day(classes2);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddWednesday(wednesday);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        ExtraStudyStream stream2 = new ExtraStudyStream(25, tintMegaFaculty, timeTable2);

        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        streams.Add(stream2);

        GroupName groupName = new GroupName("N3105");
        Group newGroup = _isuExtraService.AddGroup(groupName);
        ExtraGroup newExtraGroup = _isuExtraService.GetExtraGroup(groupName);
        Student newStudent = _isuExtraService.AddStudent(newGroup, "Ivan Ivanov");
        ExtraStudent newExtraStudent = _isuExtraService.GetExtraStudent(newStudent.Id);

        StudyClass class5 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 7, "666", "oop");
        StudyClass class6 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 8, "666", "oop");
        StudyClass?[] classes3 = new[] { null, null, null, null, null, null, class5, class6 };
        Day monday2 = new Day(classes3);
        TimeTable.TimeTableBuilder builderMon2 = new TimeTable.TimeTableBuilder();
        builderMon2.AddMonday(monday2);
        var timeTable3 = builderMon2.Build();

        _isuExtraService.AddTimeTableToGroup(timeTable3, newExtraStudent.ExtraGroup);

        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);
        _isuExtraService.AddExtraStudyToStudent(newExtraStudent, tintMegaFaculty);
        Assert.Equal(newExtraStudent.ExtraStudyStream, stream2);
    }

    [Fact]
    public void DeleteExtraStudyStudent()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");
        MegaFacultyName ctamMegaFaculty = new MegaFacultyName("CTaM");

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes1 = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes1);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security");
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security");
        StudyClass?[] classes2 = new[] { class3, null, class4, null, null, null, null, null };
        Day wednesday = new Day(classes2);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddWednesday(wednesday);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        ExtraStudyStream stream2 = new ExtraStudyStream(25, tintMegaFaculty, timeTable2);

        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        streams.Add(stream2);

        GroupName groupName = new GroupName("N3105");
        Group newGroup = _isuExtraService.AddGroup(groupName);
        ExtraGroup newExtraGroup = _isuExtraService.GetExtraGroup(groupName);
        Student newStudent = _isuExtraService.AddStudent(newGroup, "Ivan Ivanov");
        ExtraStudent newExtraStudent = _isuExtraService.GetExtraStudent(newStudent.Id);

        StudyClass class5 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 7, "666", "oop");
        StudyClass class6 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 8, "666", "oop");
        StudyClass?[] classes3 = new[] { null, null, null, null, null, null, class5, class6 };
        Day monday2 = new Day(classes3);
        TimeTable.TimeTableBuilder builderMon2 = new TimeTable.TimeTableBuilder();
        builderMon2.AddMonday(monday2);
        var timeTable3 = builderMon2.Build();

        _isuExtraService.AddTimeTableToGroup(timeTable3, newExtraGroup);

        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);
        _isuExtraService.AddExtraStudyToStudent(newExtraStudent, tintMegaFaculty);
        _isuExtraService.DeleteExtraStudyStudent(newExtraStudent);
        Assert.Null(newExtraStudent.ExtraStudyStream);
    }

    [Fact]
    public void GetExtraStudyStream()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes1 = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes1);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security");
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security");
        StudyClass?[] classes2 = new[] { class3, null, class4, null, null, null, null, null };
        Day wednesday = new Day(classes2);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddWednesday(wednesday);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        ExtraStudyStream stream2 = new ExtraStudyStream(25, tintMegaFaculty, timeTable2);

        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        streams.Add(stream2);
        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);

        IReadOnlyCollection<ExtraStudyStream> actualListStreams = _isuExtraService.GetStudyStreams(newExtraStudy);
        Assert.Equal(streams, actualListStreams);
    }

    [Fact]
    public void GetStudentsFromExtraStudyStream()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes1 = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes1);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security");
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security");
        StudyClass?[] classes2 = new[] { class3, null, class4, null, null, null, null, null };
        Day wednesday = new Day(classes2);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddWednesday(wednesday);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        ExtraStudyStream stream2 = new ExtraStudyStream(25, tintMegaFaculty, timeTable2);

        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        streams.Add(stream2);
        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);

        GroupName groupName = new GroupName("N3105");
        Group newGroup = _isuExtraService.AddGroup(groupName);
        ExtraGroup newExtraGroup = _isuExtraService.GetExtraGroup(groupName);
        Student newStudent = _isuExtraService.AddStudent(newGroup, "Ivan Ivanov");
        Student newStudent1 = _isuExtraService.AddStudent(newGroup, "Suren Ivanov");
        Student newStudent2 = _isuExtraService.AddStudent(newGroup, "Liza Ivanova");

        StudyClass class5 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 7, "666", "oop");
        StudyClass class6 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 8, "666", "oop");
        StudyClass?[] classes3 = new[] { null, null, null, null, null, null, class5, class6 };
        Day monday2 = new Day(classes3);
        TimeTable.TimeTableBuilder builderMon2 = new TimeTable.TimeTableBuilder();
        builderMon2.AddMonday(monday2);
        var timeTable3 = builderMon2.Build();

        _isuExtraService.AddTimeTableToGroup(timeTable3, newExtraGroup);
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent.Id), tintMegaFaculty);
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent1.Id), tintMegaFaculty);
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent2.Id), tintMegaFaculty);

        IReadOnlyCollection<ExtraStudent> actualListStudents = new List<ExtraStudent>()
        {
            _isuExtraService.GetExtraStudent(newStudent.Id),
            _isuExtraService.GetExtraStudent(newStudent1.Id),
            _isuExtraService.GetExtraStudent(newStudent2.Id),
        };

        Assert.Equal(_isuExtraService.GetStudentsOnStudyStream(stream2), actualListStudents);
    }

    [Fact]
    public void GetStudentsWithoutExtraStudyStream()
    {
        MegaFacultyName tintMegaFaculty = new MegaFacultyName("TInT");

        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security");
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security");
        StudyClass?[] classes1 = new[] { null, class1, class2, null, null, null, null, null };
        Day monday = new Day(classes1);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddMonday(monday);
        var timeTable1 = builderMon.Build();

        StudyClass class3 = new ExtraStudyClass(new Lecturer("Oleg"), 1, "228", "information security");
        StudyClass class4 = new ExtraStudyClass(new Lecturer("Oleg"), 3, "228", "information security");
        StudyClass?[] classes2 = new[] { class3, null, class4, null, null, null, null, null };
        Day wednesday = new Day(classes2);
        TimeTable.TimeTableBuilder builderWed = new TimeTable.TimeTableBuilder();
        builderWed.AddWednesday(wednesday);
        var timeTable2 = builderWed.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, tintMegaFaculty, timeTable1);
        ExtraStudyStream stream2 = new ExtraStudyStream(25, tintMegaFaculty, timeTable2);

        List<ExtraStudyStream> streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        streams.Add(stream2);
        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", tintMegaFaculty, streams);

        GroupName groupName = new GroupName("N3105");
        Group newGroup = _isuExtraService.AddGroup(groupName);
        ExtraGroup newExtraGroup = _isuExtraService.GetExtraGroup(groupName);
        Student newStudent = _isuExtraService.AddStudent(newGroup, "Ivan Ivanov");
        Student newStudent1 = _isuExtraService.AddStudent(newGroup, "Suren Ivanov");
        Student newStudent2 = _isuExtraService.AddStudent(newGroup, "Liza Ivanova");

        StudyClass class5 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 7, "666", "oop");
        StudyClass class6 = new GroupStudyClass(newGroup, new Lecturer("Ronimizy"), 8, "666", "oop");
        StudyClass?[] classes3 = new[] { null, null, null, null, null, null, class5, class6 };
        Day monday2 = new Day(classes3);
        TimeTable.TimeTableBuilder builderMon2 = new TimeTable.TimeTableBuilder();
        builderMon2.AddMonday(monday2);
        var timeTable3 = builderMon2.Build();

        _isuExtraService.AddTimeTableToGroup(timeTable3, newExtraGroup);
        _isuExtraService.AddExtraStudyToStudent(_isuExtraService.GetExtraStudent(newStudent.Id), tintMegaFaculty);

        IReadOnlyCollection<ExtraStudent> actualListStudents = new List<ExtraStudent>()
        {
            _isuExtraService.GetExtraStudent(newStudent1.Id),
            _isuExtraService.GetExtraStudent(newStudent2.Id),
        };

        Assert.Equal(_isuExtraService.StudentsWithoutExtraStudy(newExtraGroup), actualListStudents);
    }
}