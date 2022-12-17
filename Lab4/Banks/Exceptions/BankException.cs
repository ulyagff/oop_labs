namespace Banks.Exceptions;

public class BankException : Exception
{
    public BankException()
            : base() { }
    public BankException(string message)
            : base(message) { }
}