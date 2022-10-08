using Shops.CustomException;
using Shops.Models;
namespace Shops.Entities;

public class Shop
{
    private ShopStorage _storage;

    public Shop(string? name, string? address)
    {
        Id = Guid.NewGuid();
        if (name == null) throw new ArgumentNullException("name");
        else Name = name;
        if (address == null) throw new ArgumentNullException("address");
        else Address = address;
        _storage = new ShopStorage();
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Address { get; }

    public void ChangePrice(Product product, decimal price)
    {
        _storage.ChangePrice(product, price);
    }

    public decimal RequestPrice(List<ProductInCustomerBasket> basket)
    {
        decimal totalPrice = 0;
        foreach (var product in basket)
        {
            if (_storage.FindProduct(product.ProductName) == null)
                return -1;
            if (_storage.RequestAmount(product.ProductName) < product.Amount)
                return -1;
            totalPrice += _storage.RequestPrice(product);
        }

        return totalPrice;
    }

    public void Delivery(List<ProductInformation> deliveredProducts)
    {
        _storage.AddProducts(deliveredProducts);
    }

    public void Buy(Customer customer, List<ProductInCustomerBasket> basket)
    {
        foreach (var product in basket)
        {
            decimal totalPrice;

            if (_storage.RequestAmount(product.ProductName) <= product.Amount)
                throw ShopException.NotEnoughProductInShop(product);

            while (!_storage.AlreadyContainsProduct(product))
            {
                totalPrice = _storage.ActualProductInformation(product).Amount * _storage.ActualProductInformation(product).Price;
                if (totalPrice > customer.Balance)
                    throw ShopException.InsufficientFunds();
                customer.Balance -= totalPrice;
                product.Amount -= _storage.ActualProductInformation(product).Amount;
                _storage.DeleteProducts(product);
            }

            if (_storage.AlreadyContainsProduct(product))
            {
                totalPrice = product.Amount * _storage.ActualProductInformation(product).Price;
                if (totalPrice > customer.Balance)
                    throw ShopException.InsufficientFunds();
                customer.Balance -= totalPrice;
                _storage.ActualProductInformation(product).Amount -= product.Amount;
                product.Amount = 0;
                _storage.TryDeleteProducts(product);
            }
        }
    }
}