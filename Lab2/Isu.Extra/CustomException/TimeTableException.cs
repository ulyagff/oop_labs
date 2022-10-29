using Isu.Extra.Models;
namespace Isu.Extra.Exception;

public class TimeTableException : IsuExtraException
{
    private TimeTableException(string message) { }

    public static TimeTableException InvalidClassesCount(string message = "")
    {
        return new TimeTableException($"the number of classes should be 8. {message}");
    }

    public static TimeTableException StudyClassIsContained(string message = "")
    {
        return new TimeTableException($"StudyClass is already contained in the time table. {message}");
    }

    public static TimeTableException UseEmptyTimeTable(string message = "")
    {
        return new TimeTableException($"the time table is empty. {message}");
    }
}