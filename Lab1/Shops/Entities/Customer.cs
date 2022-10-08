using Shops.CustomException;
namespace Shops.Entities;

public class Customer
{
    private decimal _balance;
    public Customer(decimal balance)
    {
        Balance = balance;
    }

    public Customer()
    {
            Balance = 0;
    }

    public decimal Balance
    {
        get => _balance;
        set
        {
            if (value < 0)
                throw CustomerException.NegativeBalance();
            _balance = value;
        }
    }
}