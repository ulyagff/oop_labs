namespace Banks.Exceptions;

public class CentralBankException : BankException
{
    private CentralBankException(string message) { }

    public static CentralBankException BankExists()
    {
        return new CentralBankException("Bank is already exists");
    }
}