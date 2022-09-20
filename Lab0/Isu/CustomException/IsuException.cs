namespace Isu.CustomException;

public class IsuException : System.Exception
{
    public IsuException(string message)
        : base(message) { }
    public IsuException(int value, string message)
        : base(message)
    {
        Value = value;
    }

    public int Value { get; set; }
}