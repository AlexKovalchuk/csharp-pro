namespace AnimalHotel.Animals;

// https://refactoring.guru/design-patterns/abstract-factory
public class AnimalFactory : IAnimalFactory
{
    public Dog CreateDog(string name, Owner owner, int age, string color)
    {
        // business rules
        return Dog.CreateDog(name, owner, age, color);
    }
    
    public Cat CreateCat(string name, Owner owner, int age, string color)
    {
        // business rules
        return Cat.CreateCat(name, owner, age, color);
    }
}

public interface IAnimalFactory
{
    Dog CreateDog(string name, Owner owner, int age, string color);
    
    Cat CreateCat(string name, Owner owner, int age, string color);
}