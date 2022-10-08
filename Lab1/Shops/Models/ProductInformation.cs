using Shops.CustomException;
using Shops.Entities;
using Shops.Models;
namespace Shops.Models;

public class ProductInformation
{
    private decimal _price;
    private int _amount;

    public ProductInformation(Product productName, decimal price, int amount)
    {
        ProductName = productName;
        Price = price;
        if (amount < 0)
            throw ProductException.NegativeAmount();
        Amount = amount;
    }

    public Product ProductName { get; }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw ProductException.NegativePrice();
            _price = value;
        }
    }

    public int Amount
    {
        get => _amount;
        set
        {
            if (value < 0)
                throw ProductException.NegativeAmount();
            _amount = value;
        }
    }
}