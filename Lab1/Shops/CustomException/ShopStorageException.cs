using Shops.Entities;
using Shops.Models;
namespace Shops.CustomException;

public class ShopStorageException : ShopsException
{
    private ShopStorageException(string message) { }

    public static ShopStorageException NegativePrice()
    {
        return new ShopStorageException("Price must not be negative");
    }

    public static ShopStorageException ProductNotRegister(Product product)
    {
        return new ShopStorageException($"Product {product.Name}, id {product.Id.ToString()} is not registered");
    }
}