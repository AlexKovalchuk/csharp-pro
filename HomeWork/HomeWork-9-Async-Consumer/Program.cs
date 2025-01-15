namespace HomeWork_9_Async_Consumer;

class Program
{
    private static readonly string SharedFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..", "shared-folder");
    private static readonly string LogFilePath = Path.Combine(SharedFolderPath, "exchange-data.txt");
    private static FileSystemWatcher fileWatcher;
    
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, Consumer!");
        // await MonitorFileAsync();
        await StartFileWatcherAsync();
    }
    
    static async Task StartFileWatcherAsync()
    {
        var numbers = new List<int>();

        // Initialize FileSystemWatcher
        fileWatcher = new FileSystemWatcher(SharedFolderPath)
        {
            Filter = "exchange-data.txt", // Monitor specific file
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.FileName
        };

        fileWatcher.Changed += async (sender, e) => await OnFileChangedAsync(numbers);
        fileWatcher.EnableRaisingEvents = true; // Start watching the file

        Console.WriteLine("Watching for file changes...");
        await Task.Delay(Timeout.Infinite); // Keep the application running
    }
    
    static async Task OnFileChangedAsync(List<int> numbers)
    {
        try
        {
            // Read new numbers from the file asynchronously
            var newNumbers = await ReadNumbersFromFileAsync();

            if (newNumbers.Count > 0)
            {
                
                numbers.AddRange(newNumbers); // Add to list of numbers
                DisplayAnalysis(numbers); // Display updated analysis
            }
            Console.WriteLine($"newNumbers.Count is {numbers.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file change: {ex.Message}");
        }
    }
    
    static async Task<List<int>> ReadNumbersFromFileAsync()
    {
        var newNumbers = new List<int>();

        try
        {
            using (var reader = new StreamReader(LogFilePath))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    // Split by commas or spaces and parse the numbers
                    var parts = line.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var part in parts)
                    {
                        if (int.TryParse(part, out var number))
                        {
                            newNumbers.Add(number);
                            Console.WriteLine($"New Number: {number.ToString()}");
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return newNumbers;
    }
    
    static void DisplayAnalysis(List<int> numbers)
    {
        // Mean
        var mean = numbers.Average();
    
        // Standard Deviation
        var stdDev = CalculateStandardDeviation(numbers, mean);
    
        // Mode
        var mode = numbers.GroupBy(x => x).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
    
        // Median
        var median = CalculateMedian(numbers);
        
        Console.WriteLine("Data Analysis:");
        Console.WriteLine($"Mean: {mean}");
        Console.WriteLine($"Standard Deviation: {stdDev}");
        Console.WriteLine($"Mode: {mode}");
        Console.WriteLine($"Median: {median}");
    }
    
    // Calculate Standard Deviation
    static double CalculateStandardDeviation(List<int> numbers, double mean)
    {
        var variance = numbers.Select(n => Math.Pow(n - mean, 2)).Average();
        return Math.Sqrt(variance);
    }
    
    // Calculate Median
    static double CalculateMedian(List<int> numbers)
    {
        var sorted = numbers.OrderBy(n => n).ToList();
        int count = sorted.Count;
        if (count % 2 == 1)
        {
            return sorted[count / 2];
        }
        else
        {
            return (sorted[(count / 2) - 1] + sorted[count / 2]) / 2.0;
        }
    }
}