using Shops.Entities;
namespace Shops.CustomException;

public class ShopProviderException : ShopsException
{
    private ShopProviderException(string message) { }

    public static ShopProviderException ShopIsExist(Shop shop)
    {
        return new ShopProviderException($"Shop {shop.Name}, id {shop.Id.ToString()} already exists");
    }
}