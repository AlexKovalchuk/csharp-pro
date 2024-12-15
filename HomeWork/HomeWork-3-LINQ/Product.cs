namespace HomeWork_3_LINQ;

public class Product
{
    public Product(string title, string category, double price)
    {
        Title = title;
        Category = category;
        Price = price;
    }

    public Product()
    {

    }

    public string? Title { get; set; }
    public string? Category { get; set; }
    public double? Price { get; set; }
}