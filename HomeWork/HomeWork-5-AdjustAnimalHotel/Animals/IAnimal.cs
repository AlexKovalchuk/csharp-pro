namespace AnimalHotel.Animals;

public interface IAnimal
{
    string Name { get; set; }
    int Age { get; set; }
    string Color { get; set; }
    
    public Owner Owner { get; set; }
    
    void Eat();

    void Sleep()
    {
        Console.WriteLine($"{nameof(IAnimal)} is sleeping");   
    }

    void ShowAnimalInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Color: {Color}, Owner: {Owner.Name}, OwnerAge: {Owner.Age}");
    }
}