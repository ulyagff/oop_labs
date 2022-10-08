namespace Shops.CustomException;

public class ShopsException : Exception
{
    public ShopsException()
        : base() { }
    public ShopsException(string message)
        : base(message) { }
}