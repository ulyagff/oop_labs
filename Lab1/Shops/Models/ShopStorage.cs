using Shops.CustomException;
using Shops.Entities;
namespace Shops.Models;

public class ShopStorage
{
    private Dictionary<Product, Queue<ProductInformation>> _products;

    public ShopStorage()
    {
        _products = new Dictionary<Product, Queue<ProductInformation>>();
    }

    public void AddProducts(List<ProductInformation> deliveredProducts)
    {
        foreach (var product in deliveredProducts)
        {
            if (!_products.ContainsKey(product.ProductName))
            {
                _products.Add(product.ProductName, new Queue<ProductInformation>());
            }

            _products[product.ProductName].Enqueue(product);
        }
    }

    public void ChangePrice(Product product, decimal price)
    {
        if (price <= 0)
            throw ShopStorageException.NegativePrice();
        if (!_products.ContainsKey(product))
            throw ShopStorageException.ProductNotRegister(product);
        _products[product].Peek().Price = price;
    }

    public uint RequestAmount(Product product)
    {
        if (!_products.ContainsKey(product))
            throw ShopStorageException.ProductNotRegister(product);
        return (uint)_products[product].Sum(x => x.Amount);
    }

    public decimal RequestPrice(ProductInCustomerBasket product)
    {
        decimal totalPrice = 0;
        uint productAmount = product.Amount;
        if (RequestAmount(product.ProductName) < productAmount)
            throw ShopException.NotEnoughProductInShop(product);

        foreach (var iterator in _products[product.ProductName])
        {
            if (productAmount < iterator.Amount)
            {
                totalPrice += iterator.Price * productAmount;
                iterator.Amount -= productAmount;
                return totalPrice;
            }

            totalPrice += iterator.Amount * iterator.Price;
            productAmount -= iterator.Amount;
        }

        return totalPrice;
    }

    public decimal RequestPrice(Product product)
    {
        if (!_products.ContainsKey(product))
            throw ShopStorageException.ProductNotRegister(product);
        return _products[product].Peek().Price;
    }

    public Product? FindProduct(Product product)
    {
        if (!_products.ContainsKey(product))
            return null;
        return product;
    }

    public bool AlreadyContainsProduct(ProductInCustomerBasket product)
    {
        if (!_products.ContainsKey(product.ProductName))
            throw ShopStorageException.ProductNotRegister(product.ProductName);
        if (_products[product.ProductName].Peek().Amount < product.Amount)
            return false;
        return true;
    }

    public void TryDeleteProducts(ProductInCustomerBasket product)
    {
        if (_products[product.ProductName].Peek().Amount == 0)
            _products[product.ProductName].Dequeue();
    }

    public void DeleteProducts(ProductInCustomerBasket product)
    {
        _products[product.ProductName].Dequeue();
    }

    public ProductInformation ActualProductInformation(ProductInCustomerBasket product)
    {
        return _products[product.ProductName].Peek();
    }
}