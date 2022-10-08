using Shops.Entities;

namespace Shops.CustomException;

public class CustomerException : ShopsException
{
    private CustomerException(string message) { }

    public static CustomerException NegativeBalance()
    {
        return new CustomerException("Balance must not be negative");
    }
}