using Isu.Entities;
using Isu.Extra.Exception;
using Isu.Extra.Models;

namespace Isu.Extra.Entities;

public class ExtraStudent
{
    public ExtraStudent(Student student, ExtraGroup group)
    {
        Student = student;
        ExtraGroup = group;
        ExtraStudyStream = null;
    }

    public Student Student { get; }
    public ExtraGroup ExtraGroup { get; set; }
    public ExtraStudyStream? ExtraStudyStream { get; set; }

    public void AddExtraStudy(ExtraStudyStream? extraStudyStream)
    {
        if (extraStudyStream == null)
            throw ExtraStudentException.ExtraStudyStreamIsAbsent();
        if (ExtraStudyStream != null)
            throw ExtraStudentException.StudentHasExtraStudy();
        if (ExtraGroup.TimeTable.CountStudyDays() == 0)
            throw TimeTableException.UseEmptyTimeTable();
        ExtraStudyStream = extraStudyStream;
        extraStudyStream.AddStudent(this);
    }
}