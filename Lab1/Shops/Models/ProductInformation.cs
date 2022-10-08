using Shops.CustomException;
using Shops.Entities;
using Shops.Models;
namespace Shops.Models;

public class ProductInformation
{
    private decimal _price;
    public ProductInformation(Product productName, decimal price, uint amount)
    {
        ProductName = productName;
        Price = price;
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

    public uint Amount { get; set; }
}