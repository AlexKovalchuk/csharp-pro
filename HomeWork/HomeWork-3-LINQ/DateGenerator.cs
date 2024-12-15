namespace HomeWork_3_LINQ;

public class DateGenerator
{
    public static DateTime GenerateRandomDate(int minYearsBack, int maxYearsBack)
    {
        Random random = new Random();

        // Get today's date
        DateTime today = DateTime.Today;

        // Calculate the minimum and maximum dates
        DateTime minDate = today.AddYears(-maxYearsBack);
        DateTime maxDate = today.AddYears(-minYearsBack);

        // Generate a random number of days between minDate and maxDate
        int range = (maxDate - minDate).Days;
        DateTime randomDate = minDate.AddDays(random.Next(range));

        return randomDate;
    }
}