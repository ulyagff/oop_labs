namespace Isu.Extra.Exception;

public class MegaFacultyNameException : IsuExtraException
{
    private MegaFacultyNameException(string message) { }

    public static MegaFacultyNameException MegaFacultyIsAbsent(string megaFaculty, string message = "")
    {
        return new MegaFacultyNameException($"Megafaculty {megaFaculty} is missing in the university. {message}");
    }
}