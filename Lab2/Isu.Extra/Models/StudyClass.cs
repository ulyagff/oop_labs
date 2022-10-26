using Isu.Entities;
using Isu.Extra.Entities;
namespace Isu.Extra.Models;

public class StudyClass
{
    public StudyClass(Lecturer lecturer, int classTime, string nameStudyClass)
    {
        ArgumentNullException.ThrowIfNull(lecturer);
        Lecturer = lecturer;
        if (classTime < 9 && classTime > 0)
            ClassTime = classTime;
        ArgumentNullException.ThrowIfNull(nameStudyClass);
        NameStudyClass = nameStudyClass;
    }

    public Lecturer Lecturer { get; }
    public int ClassTime { get; }
    public string NameStudyClass { get; }
}