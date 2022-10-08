using Shops.CustomException;
namespace Shops.Entities;

public class Customer
{
    public Customer(decimal balance = 0)
    {
        Balance = balance;
    }

    public decimal Balance { get; private set; }

    public void TakeMoney(decimal sum)
    {
        if (Balance < sum)
            throw CustomerException.InsufficientFunds();
        Balance -= sum;
    }
}