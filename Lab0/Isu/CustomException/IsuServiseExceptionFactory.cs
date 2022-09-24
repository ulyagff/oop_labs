namespace Isu.CustomException;

public static class IsuServiseExceptionFactory
{
    public static IsuServiseException StudentIsMissing(int value, string message = "")
    {
        string basicMessage = string.Format("Student with Id {0} is missing. {1}", value, message);
        return new IsuServiseException(basicMessage);
    }

    public static IsuServiseException CourseIsMissing(int numOfCourse, int value = 0, string message = "")
    {
        string basicMessage = string.Format("The course {0} is not contained at the university. {1}", numOfCourse, message);
        return new IsuServiseException(basicMessage);
    }

    public static IsuServiseException GroupIsMissing(string nameOfGroup, string message = "")
    {
        string basicMessage = string.Format("The group {0} is not contained at the university. {1}", nameOfGroup, message);
        return new IsuServiseException(basicMessage);
    }
}