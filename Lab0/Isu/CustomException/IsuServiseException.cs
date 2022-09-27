namespace Isu.CustomException;

public class IsuServiseException : IsuException
{
    private IsuServiseException(string message)
        : base(message) { }

    public static IsuServiseException StudentIsMissing(int id, string message = "")
    {
        return new IsuServiseException($"Student with Id {id} is missing. {message}");
    }

    public static IsuServiseException CourseIsMissing(int numOfCourse, string message = "")
    {
        return new IsuServiseException($"The course {numOfCourse} is not contained at the university. {message}");
    }

    public static IsuServiseException GroupIsMissing(string nameOfGroup, string message = "")
    {
        return new IsuServiseException($"The group {nameOfGroup} is not contained at the university. {message}");
    }
}