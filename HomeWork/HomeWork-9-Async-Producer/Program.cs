namespace HomeWork_9_Async_Producer;

class Program
{
    private static string SharedFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "shared-folder");
    private static readonly Mutex FileMutex = new Mutex(); // Create a Mutex to ensure thread safety

    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, Producer!");
        await ProducerIsWorking();
    }

    static async Task ProducerIsWorking()
    {
        string logFilePath = Path.Combine(SharedFolderPath, "exchange-data.txt");
        // Clear the file before writing new data
        if (File.Exists(logFilePath))
        { 
            await File.WriteAllTextAsync(logFilePath, string.Empty);  // This clears the file
        }
        var random = new Random();
        
        
        for (int i = 0; i < 60; i++)
        {
            var randomInt = random.Next(0, 1001);

            using (StreamWriter writer = new StreamWriter(logFilePath, append: true))
            {
                // Asynchronously write the number to the file
                await writer.WriteLineAsync($"{randomInt.ToString()}, ");
                Console.WriteLine($"add new number: {randomInt.ToString()}");
            }
            
            await Task.Delay(100);
        }
    }
}