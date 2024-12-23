namespace AnimalHotel;

public class Owner(string name, string phoneNumber, int age)
{
    public string Name { get; set; } = name;

    public string PhoneNumber { get; set; } = phoneNumber;
    
    public int Age { get; set; } = age;
}