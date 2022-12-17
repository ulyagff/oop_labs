namespace Banks.Exceptions;

public class BankAccountException : BankException
{
    private BankAccountException(string message) { }

    public static BankAccountException NotEnoughMoney()
    {
        return new BankAccountException("not enough money on the balance sheet");
    }

    public static BankAccountException TransactionNotFound()
    {
        return new BankAccountException("transaction not found");
    }

    public static BankAccountException TransactionCanceled()
    {
        return new BankAccountException("the transaction has already been canceled");
    }
}