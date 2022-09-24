namespace Isu.CustomException;

public class EntitiesNameExceptionFactory
{
    public static EntitiesNameException NullGroupName(string message = "")
    {
        string basicMessage = string.Format("Null string. {0}", message);
        return new EntitiesNameException(basicMessage);
    }

    public static EntitiesNameException IncorrectLengthGroupName(int value, string message = "")
    {
        string basicMessage = string.Format("Incorrect length of group name. Given length - {0}, you need - 5. {1}", value, message);
        return new EntitiesNameException(basicMessage);
    }

    public static EntitiesNameException IncorrectSymbolGroupName(int value, string message = "")
    {
        string basicMessage = string.Format("Incorrect symbol in group name. Position - {0}. {1}", value, message);
        return new EntitiesNameException(basicMessage);
    }

    public static EntitiesNameException IncorrectCourseNumber(int value, string message = "")
    {
        string basicMessage = string.Format("Course number must be between 1 and 6. In arguments - {0}. {1}", value, message);
        return new EntitiesNameException(basicMessage);
    }

    public static EntitiesNameException FacultyIsAbsent(char facultyLetter, string message = "")
    {
        string basicMessage = string.Format("faculty with the letter {2} is missing in the university. {1}", message, facultyLetter);
        return new EntitiesNameException(basicMessage);
    }
}