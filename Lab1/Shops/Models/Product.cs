using System.Text.RegularExpressions;

namespace Shops.Models;

public class Product
{
    public Product(string? name)
    {
        if (name == null) throw new ArgumentNullException("name");
        else Name = name;
        Id = Guid.NewGuid();
    }

    public string Name { get; }
    public Guid Id { get; }
}