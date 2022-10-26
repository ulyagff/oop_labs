using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;

namespace Isu.Extra.Entities;

public class ExtraStudy
{
    public ExtraStudy(string? name, MegaFacultyName? megaFaculty, List<ExtraStudyStream> streams)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        ArgumentNullException.ThrowIfNull(megaFaculty);
        MegaFaculty = megaFaculty;
        if (!streams.Any())
            throw ExtraStudyException.StreamsListIsEmpty();
        Streams = streams;
    }

    public string Name { get; }
    public MegaFacultyName MegaFaculty { get; }
    public List<ExtraStudyStream> Streams { get; }

    public IReadOnlyCollection<ExtraStudyStream> GetExtraStudyStreams()
    {
        return Streams;
    }
}