using Isu.Entities;
using Isu.Extra.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;
using Isu.Services;

namespace Isu.Extra.Services;

public interface IIsuServiceDecorator : IIsuService
{
    public ExtraStudy AddExtraStudy(string name, MegaFaculty megaFaculty, List<ExtraStudyStream> streams);

    public void AddTimeTableToGroup(TimeTable timeTable, ExtraGroup extraGroup);

    public void AddExtraStudyToStudent(ExtraStudent student, MegaFaculty megaFaculty);

    public void DeleteExtraStudyStudent(ExtraStudent student);

    public IReadOnlyCollection<ExtraStudyStream> GetStudyStreams(ExtraStudy extraStudy);
    public IReadOnlyCollection<ExtraStudent> GetStudentsOnStudyStream(ExtraStudyStream extraStudyStream);
    public IReadOnlyCollection<ExtraStudent> StudentsWithoutExtraStudy(ExtraGroup group);
    public IReadOnlyCollection<ExtraStudy> GetListExtraStudy();

    public ExtraGroup GetExtraGroup(GroupName groupName);
    public ExtraStudent GetExtraStudent(IsuIdentifier id);
}