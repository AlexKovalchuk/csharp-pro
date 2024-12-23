namespace HomeWork_5_AdjustAnimalHotel;

using AnimalHotel;
using AnimalHotel.Animals;
using AnimalHotel.Hotel;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work 5!");

        var animalNames = new string[] { "Dog", "Cat", "Parrot", "Horse" };
        var animalColors = new string[] { "Gray", "Black", "White", "Golden" };
        var ownerNames = new string[] { "John", "Jane", "Jack", "Jill" , "", ""};
        var ownerPhoneNumbers = new string[] { "1234567890", "0987654321", "6789054321", "1234509876" };

        var list = new List<int>();

        IAnimalFactory animalFactory = new AnimalFactory();
        var random = new Random();
        var cats = new GenericHotel<Cat>();
        var genericHotel = new GenericHotel<IAnimal>();
        var kyivHotel = new KyivHotel();
        var romashkaHotel = new RomashkaHotel();

        for (int i = 0; i < 10; i++)
        {
            var animalName = animalNames[random.Next(animalNames.Length)];
            var animalColor = animalColors[random.Next(animalColors.Length)];
            var animalAge = random.Next(1, 15);
            var ownerName = ownerNames[random.Next(ownerNames.Length)];
            var ownerPhoneNumber = ownerPhoneNumbers[random.Next(ownerPhoneNumbers.Length)];
            var ownerAge = random.Next(16,90);
            var animalType = random.Next(2);

            var owner = new Owner(ownerName, ownerPhoneNumber, ownerAge);
            IAnimal animal = animalType switch
            {
                0 => animalFactory.CreateDog(animalName, owner, animalAge, animalColor),
                1 => animalFactory.CreateCat(animalName, owner, animalAge, animalColor),
                _ => throw new ArgumentException("Invalid animal type"),
            };

            genericHotel.AddAnimal(animal);
            kyivHotel.AddAnimal(animal);
            romashkaHotel.AddAnimal(animal);
        }

        Console.WriteLine("");
        Console.WriteLine("-------------GENERIC HOTEL START------------");
        
        foreach (var animal in genericHotel)
        {
            animal.ShowAnimalInfo();
            animal.Eat();
        }
        genericHotel.Sort();
        Console.WriteLine("-------------GENERIC HOTEL After SORING------------");
        genericHotel.PrintAnimals();
        Console.WriteLine("-------------GENERIC HOTEL: Pats who owner has a name------------");
        var genericNames = genericHotel.GetAnimalsWithOwner();
        foreach (var animal in genericNames)
        {
            animal.ShowAnimalInfo();
            animal.Eat();
            animal.Sleep();
        }
        genericHotel.FeedAnimals();
        genericHotel.PutAnimalsToSleep();

        Console.WriteLine("");
        Console.WriteLine("-------------KYIV HOTEL START------------");
        
        foreach (var animal in kyivHotel)
        {
            animal.ShowAnimalInfo();
            animal.Sleep();
        }
        kyivHotel.Sort();
        Console.WriteLine("-------------KYIV HOTEL After SORING------------");
        kyivHotel.PrintAnimals();
        Console.WriteLine("-------------KYIV HOTEL: Pats who owner has a name------------");
        var kyivHotelNames = kyivHotel.GetAnimalsWithOwner();
        foreach (var animal in kyivHotelNames)
        {
            animal.ShowAnimalInfo();
        }
        kyivHotel.FeedAnimals();
        kyivHotel.PutAnimalsToSleep();
        
        Console.WriteLine("");
        Console.WriteLine("-------------ROMASHKA HOTEL START------------");

        foreach (var animal in romashkaHotel)
        {
            (animal as IAnimal)?.ShowAnimalInfo();
        }
        romashkaHotel.Sort();
        Console.WriteLine("-------------ROMASHKA HOTEL After SORING------------");
        romashkaHotel.PrintAnimals();
        Console.WriteLine("-------------ROMASHKA HOTEL: Pats who owner has a name------------");
        var romashkaHotelNames = romashkaHotel.GetAnimalsWithOwner();
        foreach (var animal in romashkaHotelNames)
        {
            (animal as IAnimal)?.ShowAnimalInfo();
        }
        romashkaHotel.FeedAnimals();
        romashkaHotel.PutAnimalsToSleep();

// TODO: get all animals with name 'Parrot' from genericHotel
        var genericHotelParrots = genericHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from kyivHotel
        var kyivHotelParrots = kyivHotel.Where(x => x.Name == "Parrot");

// TODO: get all animals with name 'Parrot' from romashkaHotel
        var romashkaHotelParrots = romashkaHotel.OfType<Cat>();

// TODO: extend animals entity to have a property 'Age' and sort animals by age
    }
}