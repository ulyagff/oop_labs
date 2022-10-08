using Shops.CustomException;
using Shops.Entities;
using Shops.Models;

namespace Shops.Manager;

public class ShopsProvider
{
    private List<Shop> _shops;

    public ShopsProvider()
    {
        _shops = new List<Shop>();
    }

    public Shop AddShop(string name, string address)
    {
        var shop = new Shop(name, address);
        if (_shops.Contains(shop))
            throw ShopProviderException.ShopIsExist(shop);
        _shops.Add(shop);
        return shop;
    }

    public Shop? FindLowestPrice(List<ProductInCustomerBasket> basket)
    {
        return _shops
            .Where(i => i.RequestPrice(basket) != -1)
            .MinBy(i => i.RequestPrice(basket));
    }
}