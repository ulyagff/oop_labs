﻿using Shops.Entities;
using Shops.Models;

namespace Shops.CustomException;

public class ShopException : ShopsException
{
    private ShopException(string message) { }

    public static ShopException NotEnoughProductInShop(ProductInCustomerBasket product)
    {
        return new ShopException(
            $"Product {product.ProductName.Name}, id {product.ProductName.Id.ToString()} in the amount of {product.Amount} is not in the Shop");
    }
}