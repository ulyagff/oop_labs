namespace Shops.CustomException;

public class ProductException : ShopsException
{
    private ProductException(string message) { }

    public static ProductException NegativePrice()
    {
        return new ProductException("Price must not be negative");
    }

    public static ProductException NegativeAmount()
    {
        return new ProductException("Amount must not be negative");
    }
}