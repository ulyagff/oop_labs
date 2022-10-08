namespace Isu.CustomException;

public class CourseNameException : IsuException
{
    private CourseNameException(string message) { }

    public static CourseNameException IncorrectCourseNumber(int value, string message = "")
    {
        return new CourseNameException($"Course number must be between 1 and 6. In arguments - {value}. {message}");
    }
}