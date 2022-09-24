namespace Isu.CustomException;

public class IsuServiseException : System.Exception
{
    public IsuServiseException(string message)
        : base(message) { }
}