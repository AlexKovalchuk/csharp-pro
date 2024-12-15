using System.Runtime.InteropServices.JavaScript;

namespace HomeWork_3_LINQ;

public class Employee
{

    public Employee(string name, string surname, DateTime birthday, DateTime employedDate)
    {
        Name = name;
        Surname = surname;
        Birthday = birthday;
        EmployedDate = employedDate;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime EmployedDate { get; set; }
}