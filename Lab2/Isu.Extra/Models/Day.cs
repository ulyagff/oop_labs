using Isu.Extra.Exception;
namespace Isu.Extra.Models;

public class Day
{
    public Day(StudyClass?[] classes)
    {
        if (classes.Length != 8)
            throw TimeTableException.InvalidClassesCount();
        Classes = classes;
    }

    public StudyClass?[] Classes { get; }

    public bool IsIntersection(Day otherDay)
    {
        for (int i = 0; i < 8; i++)
        {
            if (Classes[i] != null && otherDay.Classes != null)
                return true;
        }

        return false;
    }
}