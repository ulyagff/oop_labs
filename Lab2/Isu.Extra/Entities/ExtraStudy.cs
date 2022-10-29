using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;

namespace Isu.Extra.Entities;

public class ExtraStudy
{
    private List<ExtraStudyStream> _streams;
    public ExtraStudy(string? name, MegaFaculty? megaFaculty, List<ExtraStudyStream> streams)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        ArgumentNullException.ThrowIfNull(megaFaculty);
        MegaFaculty = megaFaculty;
        if (!streams.Any())
            throw ExtraStudyException.StreamsListIsEmpty();
        _streams = streams;
    }

    public string Name { get; }
    public MegaFaculty MegaFaculty { get; }
    public IReadOnlyCollection<ExtraStudyStream> GetExtraStudyStreams() => _streams;

    public void AddExtraStudyStreamToStudent(ExtraStudent student)
    {
        var extraStudyStreamForStudent = _streams
            .Where(i => !i.IsFull())
            .Where(i => !i.TimeTable.IsIntersection(student.ExtraGroup.TimeTable))
            .ToList()
            .FirstOrDefault();
        student.AddExtraStudy(extraStudyStreamForStudent);
    }
}