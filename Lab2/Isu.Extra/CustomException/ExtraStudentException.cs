namespace Isu.Extra.Exception;

public class ExtraStudentException : IsuExtraException
{
    private ExtraStudentException(string message) { }

    public static ExtraStudentException StudentHasExtraStudy(string message = "")
    {
        return new ExtraStudentException($"the student already has a extra study. {message}");
    }

    public static ExtraStudentException StudentHasNotExtraStudy(string message = "")
    {
        return new ExtraStudentException($"the student has not a extra study. {message}");
    }
}