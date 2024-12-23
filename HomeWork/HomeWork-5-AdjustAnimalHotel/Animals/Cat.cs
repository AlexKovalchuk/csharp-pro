namespace AnimalHotel.Animals;

public class Cat : IAnimal, IComparable<Cat>
{
    private Cat(string name, Owner owner, int age, string color)
    {
        Name = name;
        Owner = owner;
        Age = age;
        Color = color;
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Owner Owner { get; set; }

    public void Meow()
    {
        Console.WriteLine($"{nameof(Cat)} is meowing");
    }
    
    public void Eat()
    {
        Console.WriteLine($"{nameof(Cat)} is eating");
    }

    public void Sleep()
    {
        Console.WriteLine($"{nameof(Cat)} is sleeping");
    }
    
    public static Cat CreateCat(string name, Owner owner, int age, string color)
    {
        return new Cat(name, owner, age, color);
    }
    
    // https://refactoring.guru/design-patterns/factory-method
    public int CompareTo(Cat? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (other is null) return 1;
        return string.Compare(Name, other.Name, StringComparison.Ordinal);
    }
}