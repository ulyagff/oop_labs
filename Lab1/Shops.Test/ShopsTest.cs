using Shops.CustomException;
using Shops.Entities;
using Shops.Manager;
using Shops.Models;
using Xunit;

namespace Shops.Test;

public class ShopsTest
{
    private ShopsProvider _provider;

    public ShopsTest()
    {
        _provider = new ShopsProvider();
    }

    [Fact]
    public void DeliveryToShop()
    {
        var shop1 = _provider.AddShop("Amazon", "Kommunist st.");
        var customer1 = new Customer(1000);
        var product1 = new Product("vodka");
        var product2 = new Product("beer");
        var product3 = new Product("grass");
        var deliveryProducts = new List<ProductInformation>();
        deliveryProducts.Add(new ProductInformation(product1, 100, 50));
        deliveryProducts.Add(new ProductInformation(product2, 60, 80));
        deliveryProducts.Add(new ProductInformation(product3, 1500, 100));
        var shoppingBag = new List<ProductInCustomerBasket>();
        shoppingBag.Add(new ProductInCustomerBasket(product1, 1));
        shop1.Delivery(deliveryProducts);
        decimal recPrice = shop1.TotalPrice(shoppingBag);

        shop1.Buy(customer1, shoppingBag);
        Assert.Equal(customer1.Balance, 1000 - recPrice);
    }

    [Fact]
    public void ChangePrice()
    {
        var shop1 = _provider.AddShop("Amazon", "Kommunist st.");
        var product1 = new Product("vodka");
        var deliveryProducts = new List<ProductInformation>();
        deliveryProducts.Add(new ProductInformation(product1, 100, 50));
        var shoppingBag = new List<ProductInCustomerBasket>();
        shoppingBag.Add(new ProductInCustomerBasket(product1, 1));
        shop1.Delivery(deliveryProducts);
        shop1.ChangePrice(product1, 150);
        Assert.Equal(150, shop1.TotalPrice(shoppingBag));
    }

    [Fact]
    public void FindTheLowestPrice()
    {
        var shop1 = _provider.AddShop("Amazon", "Kommunist st.");
        var shop2 = _provider.AddShop("Perek", "Chaikovskogo st.");

        var product1 = new Product("vodka");
        var product2 = new Product("beer");
        var product3 = new Product("grass");
        var deliveryProducts1 = new List<ProductInformation>();
        deliveryProducts1.Add(new ProductInformation(product1, 100, 50));
        deliveryProducts1.Add(new ProductInformation(product2, 60, 80));
        deliveryProducts1.Add(new ProductInformation(product3, 800, 100));
        shop1.Delivery(deliveryProducts1);

        var deliveryProducts2 = new List<ProductInformation>();
        deliveryProducts2.Add(new ProductInformation(product1, 100, 50));
        deliveryProducts2.Add(new ProductInformation(product2, 60, 80));
        deliveryProducts2.Add(new ProductInformation(product3, 700, 100));
        shop2.Delivery(deliveryProducts2);

        var shoppingBag = new List<ProductInCustomerBasket>();
        shoppingBag.Add(new ProductInCustomerBasket(product1, 1));
        shoppingBag.Add(new ProductInCustomerBasket(product2, 7));
        shoppingBag.Add(new ProductInCustomerBasket(product3, 1));

        Assert.Equal(shop2, _provider.FindLowestPrice(shoppingBag));
    }

    [Fact]
    public void BuyProducts()
    {
        var shop1 = _provider.AddShop("Amazon", "Kommunist st.");
        var customer1 = new Customer(10000);
        var product1 = new Product("vodka");
        var product2 = new Product("beer");
        var product3 = new Product("grass");
        var deliveryProducts = new List<ProductInformation>();
        deliveryProducts.Add(new ProductInformation(product1, 100, 50));
        deliveryProducts.Add(new ProductInformation(product2, 60, 80));
        deliveryProducts.Add(new ProductInformation(product3, 1500, 100));
        var shoppingBag = new List<ProductInCustomerBasket>();
        shoppingBag.Add(new ProductInCustomerBasket(product1, 1));
        shoppingBag.Add(new ProductInCustomerBasket(product2, 1));
        shoppingBag.Add(new ProductInCustomerBasket(product3, 1));

        shop1.Delivery(deliveryProducts);
        decimal recPrice = shop1.TotalPrice(shoppingBag);
        shop1.Buy(customer1, shoppingBag);
        Assert.Equal(10000 - recPrice, customer1.Balance);
    }
}