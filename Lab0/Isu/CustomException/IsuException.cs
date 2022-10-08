namespace Isu.CustomException;

public class IsuException : System.Exception
{
    public IsuException()
        : base() { }
    public IsuException(string message)
        : base(message) { }
}