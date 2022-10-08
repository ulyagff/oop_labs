using Shops.Entities;

namespace Shops.CustomException;

public class CustomerException : ShopsException
{
    private CustomerException(string message) { }

    public static CustomerException InsufficientFunds()
    {
        return new CustomerException($"There are not enough funds on the account of the customer");
    }
}