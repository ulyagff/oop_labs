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
    }

    [Fact]
    public void AddNewExtraStudy()
    {
        StudyClass class1 = new ExtraStudyClass(new Lecturer("Ronimizy"), 2, "331", "information security", DayOfWeek.Monday);
        StudyClass class2 = new ExtraStudyClass(new Lecturer("Ronimizy"), 3, "331", "information security", DayOfWeek.Monday);
        TimeTable.TimeTableBuilder builderMon = new TimeTable.TimeTableBuilder();
        builderMon.AddStudyClass(class1);
        builderMon.AddStudyClass(class2);
        var timeTable1 = builderMon.Build();
        ExtraStudyStream stream1 = new ExtraStudyStream(30, _isuExtraService.GetMegaFaculty("TInT"), timeTable1);
        var streams = new List<ExtraStudyStream>();
        streams.Add(stream1);
        ExtraStudy newExtraStudy = _isuExtraService.AddExtraStudy("Extra Study 3", _isuExtraService.GetMegaFaculty("TInT"), streams);
        Assert.Contains(newExtraStudy, _isuExtraService.GetListExtraStudy());
    }
}