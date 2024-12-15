namespace HomeWork_3_LINQ;

public class Customer
{
    public Customer(string name, string surname, string address, List<Product> products, string orderTitle)
    {
        Name = name;
        Surname = surname;
        Address = address;
        Order = new Order(orderTitle, products);
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public Order Order{ get; set; }
}