namespace HomeWork;

public class Horse : IAnimal
{

    public Horse()
    {
        Name = "a horse";
        HostName = "Driver";
        Age = 0;
    }

    public Horse(string name, string hostName, int age)
    {
        Name = name;
        HostName = hostName;
        Age = age;
    }
    public string Name { get; set; }
    public string HostName { get; set; }
    public int Age { get; set; }

    public void SaySomething()
    {
        Console.WriteLine($"{Name} says: I am mega horse");
    }
}