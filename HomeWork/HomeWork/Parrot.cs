namespace HomeWork;

public class Parrot : IAnimal
{
    public Parrot()
    {
        Name = "Parrot";
        HostName = "Owner";
        Age = 0;
    }

    public Parrot(string name, string hostName, int age)
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
        Console.WriteLine($"{Name} says: I am a perrot");
    }
}