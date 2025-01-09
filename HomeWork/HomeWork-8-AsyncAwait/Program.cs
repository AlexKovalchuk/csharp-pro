using System.Diagnostics;

namespace HomeWork_8_AsyncAwait;


// Написати програму яка буде в циклі 100 разів

// створювати файл із номером лічильника 
// записати в файл число
// видалити файл

// всі ці дії зробити спочатку синхронно і потім асинхронно.
// вивести час виконная обох задач на екран
class Program
{
    private static string CurrentDirectory = Directory.GetCurrentDirectory();
    

    static async Task Main(string[] args)
    {
        Console.WriteLine("Home Work 8!");
        CreateLogFileSync();
        await CreateLogFileAsync();
    }

    static void CreateLogFileSync()
    {
        Console.WriteLine("Sync Log File Start");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < 100; i++)
        {
            string logFilePath = Path.Combine(CurrentDirectory, $"log-{i}.txt");
            File.AppendAllText(logFilePath, $"value = {i}\n");
        }
        stopwatch.Stop();
        Console.WriteLine($"Sync Log File Finished in {stopwatch.ElapsedMilliseconds} ms");
    }
    
    static async Task CreateLogFileAsync()
    { 
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Console.WriteLine("Async Log File Start");
        var tasks = new Task[100];

        for (int i = 0; i < 100; i++)
        {
            string logFilePath = Path.Combine(CurrentDirectory, $"log-async-{i}.txt");
            tasks[i] = AppendLogAsync(logFilePath, i);
        }

        await Task.WhenAll(tasks);
        
        stopwatch.Stop();
        Console.WriteLine($"Async Log File Finished: {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task AppendLogAsync(string filePath, int value)
    {
        await File.AppendAllTextAsync(filePath, $"async value = {value}\n");
    }
}