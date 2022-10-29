using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;
using Isu.Models;

namespace Isu.Extra.Entities;

public class ExtraGroup
{
    public ExtraGroup(Group group, TimeTable timeTable, MegaFaculty? megaFaculty)
    {
        Group = group;
        TimeTable = timeTable;
        ArgumentNullException.ThrowIfNull(megaFaculty);
        MegaFaculty = megaFaculty;
    }

    public Group Group { get; }
    public MegaFaculty MegaFaculty { get; }

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