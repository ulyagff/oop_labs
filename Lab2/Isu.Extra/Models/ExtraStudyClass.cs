using Isu.Entities;
using Isu.Extra.Entities;
namespace Isu.Extra.Models;

public class ExtraStudyClass : StudyClass
{
    public ExtraStudyClass(Lecturer lecturer, int classTime, string classroom, string nameStudyClass)
        : base(lecturer, classTime, nameStudyClass)
    {
        ArgumentNullException.ThrowIfNull(classroom);
        Classroom = classroom;
    }

    public string Classroom { get; }
}