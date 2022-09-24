namespace Isu.CustomException;

public class GroupException : System.Exception
{
    public GroupException(string message)
        : base(message) { }
}