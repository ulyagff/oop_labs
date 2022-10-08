using System.Text.RegularExpressions;

namespace Shops.Models;

public class Product
{
    public Product(string? name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        Id = Guid.NewGuid();
    }

    public string Name { get; }
    public Guid Id { get; }
}