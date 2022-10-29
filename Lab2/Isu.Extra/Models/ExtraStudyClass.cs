using Isu.Entities;
using Isu.Extra.Entities;
namespace Isu.Extra.Models;

public class ExtraStudyClass : StudyClass
{
    public ExtraStudyClass(Lecturer lecturer, int classTime, string classroom, string nameStudyClass, DayOfWeek day)
        : base(lecturer, classTime, nameStudyClass, day)
    {
        ArgumentNullException.ThrowIfNull(classroom);
        Classroom = classroom;
    }

    public string Classroom { get; }
}