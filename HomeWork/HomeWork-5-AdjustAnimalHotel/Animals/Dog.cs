namespace AnimalHotel.Animals;

public class Dog : IAnimal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Owner Owner { get; set; }

    private Dog(string name, Owner owner, int age, string color)
    {
        Name = name;
        Owner = owner;
        Age = age;
        Color = color;
    }
    
    public void Bark()
    {
        Console.WriteLine($"{nameof(Dog)} is barking");
    }

    public void Eat()
    {
        Console.WriteLine($"{nameof(Dog)} is eating");
    }
    
    
    // https://refactoring.guru/design-patterns/factory-method
    public static Dog CreateDog(string name, Owner owner, int age, string color)
    {
        return new Dog(name, owner, age, color);
    }
}