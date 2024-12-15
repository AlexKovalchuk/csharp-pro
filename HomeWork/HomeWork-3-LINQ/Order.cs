namespace HomeWork_3_LINQ;

public class Order
{
    public Order(string title, List<Product> products)
    {
        Title = title;
        Products = products;
        TotalPrice = Math.Round(Products?.Sum(p => p.Price) ?? 0.0, 2);
        OrderDate = DateTime.Now;
    }

    public string Title { get; }
    public List<Product>? Products { get; set; }
    public double TotalPrice { get; }
    public DateTime OrderDate { get; }
}