namespace Isu.CustomException;

public class GroupNameException : IsuException
{
    private GroupNameException(string message) { }

    public static GroupNameException NullGroupName(string message = "")
    {
        return new GroupNameException($"Null string. {message}");
    }

    public static GroupNameException IncorrectLengthGroupName(int value, string message = "")
    {
        return new GroupNameException($"Incorrect length of group name. Given length - {value}, you need - 5. {message}");
    }

    public static GroupNameException IncorrectSymbolGroupName(int value, string message = "")
    {
        return new GroupNameException($"Incorrect symbol in group name. Position - {value}. {message}");
    }
}