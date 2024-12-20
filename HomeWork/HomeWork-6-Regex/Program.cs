using System.Text.RegularExpressions;

namespace HomeWork_6_Regex;

class Program
{
    
    static string GetBinaryNumberFromConsoleWrite()
    {
        string binaryRegex = "^[0-1]{1,}$";
        var isBinaryInput = new Regex(binaryRegex);
        string? strNum;
        do
        {
            Console.Write($"Write binary value (like 0101): ");
            strNum = Console.ReadLine();
        } while (strNum?.Length == 0 || !isBinaryInput.IsMatch(strNum));

        return strNum;
    }

    static void CheckIfBinaryNumberIsEven(string binaryNumberString)
    {
        string binaryEvenRegex = "^[0-1]{1,}0$";
        var regex = new Regex(binaryEvenRegex);
        if (regex.IsMatch(binaryNumberString))
        {
            Console.WriteLine("Binary number {binaryNumberString} is even.");
        }
        else
        {
            Console.WriteLine("Binary number {binaryNumberString} is NOT even.");
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work 6 Regex!");
        
        // 1. Створити програму яка буде приймати число у бінарному вигляді (1 та 0) у форматі рядку.
        // Якщо ви вводите хочете ввести 3 -> 11. хочете ввести 4 - 100 
        string binaryNumberFromUser = GetBinaryNumberFromConsoleWrite();
        int convertedNumber = Convert.ToInt32(binaryNumberFromUser, 2);
        Console.WriteLine($"Binary number:{binaryNumberFromUser} = {convertedNumber}");
        
        // 2. Створтити регулярний вираз який буде перевіряти чи можна поділити число без остачі на 2
        CheckIfBinaryNumberIsEven(binaryNumberFromUser);

    }
}