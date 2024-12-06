namespace HomeWork;

public class Fish : IAnimal
{
    public Fish()
    {
        Name = "a Fish";
        HostName = "Neptune";
        Age = 0;
    }

    public Fish(string name, string hostName, int age)
    {
        Name = name;
        HostName = hostName;
        Age = age;
    }

    public string Name { get; set; }
    public string HostName { get; set; }
    public int Age { get; set; }
}