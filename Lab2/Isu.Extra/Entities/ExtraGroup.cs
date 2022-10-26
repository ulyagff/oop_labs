using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;

namespace Isu.Extra.Entities;

public class ExtraGroup
{
    public ExtraGroup(Group group, TimeTable timeTable)
    {
        Group = group;
        TimeTable = timeTable;
        MegaFaculty = MegaFacultyName.CorrelateFaculty(group.Name.Faculty);
    }

    public Group Group { get; }
    public MegaFacultyName MegaFaculty { get; }

    public TimeTable TimeTable { get; private set; }

    public void SetTimeTable(TimeTable timeTable)
    {
        if (TimeTable.CountStudyDays() != 0)
            throw ExtraGroupException.GroupHasTimeTable(this);
        if (timeTable.CountStudyDays() == 0)
            throw TimeTableException.UseEmptyTimeTable();
        TimeTable = timeTable;
    }
}