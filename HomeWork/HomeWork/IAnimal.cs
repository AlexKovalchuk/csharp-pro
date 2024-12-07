namespace HomeWork;

public interface IAnimal
{
    string Name { get; set; }
    string HostName { get; set; }
    int Age { get; set; }

    void SaySomething()
    {
        Console.WriteLine(" I am default implementation");
    }

    void TellAboutYourself()
    {
        Console.WriteLine($"I am {Name} and my owner is {HostName}, I am {Age} years old");
    }
}