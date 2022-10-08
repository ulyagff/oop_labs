using Shops.CustomException;

namespace Shops.Models;

public class ProductInCustomerBasket
{
    public ProductInCustomerBasket(Product productName, int amount)
    {
        ProductName = productName;
        if (amount < 0)
            throw ProductException.NegativeAmount();
        Amount = amount;
    }

    public Product ProductName { get; }
    public int Amount { get; set; }
}