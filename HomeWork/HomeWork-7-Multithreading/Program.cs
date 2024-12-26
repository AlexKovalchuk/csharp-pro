using System.Collections.Concurrent;
using System.Text;

namespace HomeWork_7_Multithreading;

// 1. Вам потрібно два основних типи об'єктів: один для виробника (producer) та один для споживача (consumer).

// 2. Виробник циклічно генерує деякі дані та поміщає їх в буфер.

// 3. Споживач повинен брати дані з буфера й обробляти їх.

// 4. Буфер має бути реалізований таким чином, щоб він міг безпечно використовуватися з обох потоків:
//  він посилає дані виробника та забирає споживача. Зазвичай це реалізується
//  через блокування/неблокувальні структури даних або за допомогою "lock" оператора
//  для синхронізації доступу до структури даних.

// 5. Немає визначеного правила, коли виробник має створювати дані або коли споживач має їх використовувати.
//  Проте, ви не маєте дозволяти споживачу використовувати дані, які ще не були згенерованими.

// 6. Вам потрібно використовувати спеціальні методи C# для управління потоками, такі як Wait, Pulse,
//  або використовувати класи Semaphore, Mutex або Monitor.

// 7. Всі виняткові ситуації повинні бути належним чином оброблені.

// 8. Збереження логів: виводити результати роботи в файл.

class Program
{
    private static readonly object lockObj = new object();
    private static string CurrentDirectory = Directory.GetCurrentDirectory();
    private static string logFilePath = Path.Combine(CurrentDirectory, "log.txt");
    private static StringBuilder logBuilder = new StringBuilder();
    private static SafeStack<int> SafeCollection = new SafeStack<int>();


    static void Main(string[] args)
    {
        logBuilder.AppendLine("Start a new Process for working with SafeCollection.");

        var producerThread = new Thread(_ => ProducerIsWorking(750));
        var consumerThread = new Thread(_ => ConsumerIsWorking(2250));
        
        try
        {
            producerThread.Start();
            consumerThread.Start();
        
            producerThread.Join();
            consumerThread.Join();
            
            File.AppendAllText(logFilePath, logBuilder.ToString());
            Console.WriteLine("It is Done!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            File.AppendAllText(logFilePath, $"Error occurred: {ex.Message}\n");
        }
    }

    static void ProducerIsWorking(int time)
    {
        
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(time);
            lock (lockObj)
            {
                SafeCollection.TryAdd(i);
                Console.WriteLine($"Producer add value {i}");
                logBuilder.AppendLine($"Producer added value {i} into the SafeCollection.");
                Monitor.Pulse(lockObj);
            }
        }
    }

    static void ConsumerIsWorking(int time)
    {
        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(time);
            while (SafeCollection.Count == 0)
            {
                Monitor.Wait(lockObj);
            }
            
            if(SafeCollection.TryTake(out var value))
            {
                Console.WriteLine($"Consumer took value {value}");
                logBuilder.AppendLine($"Consumer took value {value} from the SafeCollection.");
            }
            else
            {
                logBuilder.AppendLine($"FAILED! Consumer could not take value {value} from the SafeCollection.\n");
                Console.WriteLine("FAILED to take a value from SafeCollection!!!");
            }
        }
    }
}