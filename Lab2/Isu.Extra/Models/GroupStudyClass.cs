using Isu.Entities;
using Isu.Extra.Entities;
namespace Isu.Extra.Models;

public class GroupStudyClass : StudyClass
{
    public GroupStudyClass(Group group, Lecturer lecturer, int classTime, string classroom, string nameStudyClass, DayOfWeek day)
        : base(lecturer, classTime, nameStudyClass, day)
    {
        ArgumentNullException.ThrowIfNull(group);
        Group = group;
        ArgumentNullException.ThrowIfNull(classroom);
        Classroom = classroom;
    }

    public Group Group { get; }
    public string Classroom { get; }
}