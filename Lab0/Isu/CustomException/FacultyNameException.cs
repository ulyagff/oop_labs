namespace Isu.CustomException;

public class FacultyNameException : IsuException
{
    private FacultyNameException(string message) { }

    public static FacultyNameException FacultyIsAbsent(char facultyLetter, string message = "")
    {
        return new FacultyNameException($"faculty with the letter {facultyLetter} is missing in the university. {message}");
    }
}