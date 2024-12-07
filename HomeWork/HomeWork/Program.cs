namespace HomeWork;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("ДЗ 1. створити класи тварин");

        var unknownParrot = new Parrot();
        Console.WriteLine($"{unknownParrot.Name}, {unknownParrot.Age},  {unknownParrot.HostName}");
        unknownParrot.SaySomething();
        var avocado = new Parrot("Avocado", "jack Sparrow", 2);
        Console.WriteLine($"{avocado.Name}, {avocado.Age},  {avocado.HostName}");
        avocado.SaySomething();

        IAnimal unknownFish = new Fish();
        unknownFish.TellAboutYourself();
        unknownFish.SaySomething();
        IAnimal nemo = new Fish("Nemo", "Ocean", 1);
        nemo.TellAboutYourself();
        nemo.SaySomething();

        IAnimal thomas = new Cat("Thomas", "Mr.Andersen", 12);
        thomas.TellAboutYourself();
        thomas.SaySomething();


        IAnimal carrot = new Horse("Carrot", "Capitan America", 6);
        carrot.TellAboutYourself();
        carrot.SaySomething();
    }
}