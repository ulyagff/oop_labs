using Shops.CustomException;

namespace Shops.Models;

public class ProductInCustomerBasket
{
    public ProductInCustomerBasket(Product productName, uint amount)
    {
        ProductName = productName;
        Amount = amount;
    }

    public Product ProductName { get; }
    public uint Amount { get; set; }
}