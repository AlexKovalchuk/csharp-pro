namespace HomeWork;

public class Cat : IAnimal
{
    public Cat()
    {
        Name = "a Cat";
        HostName = "nobody";
        Age = 0;
    }

    public Cat(string name, string hostName, int age)
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
        Console.WriteLine($"{Name} says: Mew");
    }
}