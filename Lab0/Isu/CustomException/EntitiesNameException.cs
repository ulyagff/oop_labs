namespace Isu.CustomException;

public class EntitiesNameException : System.Exception
{
    public EntitiesNameException(string message)
        : base(message) { }
}