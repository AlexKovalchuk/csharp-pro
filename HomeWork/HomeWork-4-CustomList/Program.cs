namespace HomeWork_4_CustomList;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work 4 - Custom List!");
        void CalledWhenResized(int newSize)
        {
            Console.WriteLine($"List was resized to {newSize}");
        }

        var myList = new MyList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.OnResize += CalledWhenResized;
        myList.OnResizeFunc += int (int newSize) =>
        {
            Console.WriteLine($"Resized this using FUNC {newSize}");
            return newSize;
        };
        myList.OnResizeAction += void (int newSize) =>
        {
            Console.WriteLine($"Resized this using ACTION {newSize}");
        };
        myList.OnResizePredicate = bool (int newSize) =>
        {
            Console.WriteLine($"Resized this using Predicate {newSize}");
            return true;
        };
        myList[0] = 17;
        myList[1] = 347;
        myList.Remove(347);
        myList.Add(112);
        myList.Add(527);
        myList.Add(527);
        myList.Add(372);
        myList.Add(375);
        myList.Add(382);
        myList.Add(572);
        myList.Add(262);
        myList.Add(192);
        myList.Add(738);
        myList.Add(10);
        myList.Add(3);
        myList = myList + 5;
        myList = myList + 10;
        myList = myList - 527;
        
        Console.WriteLine("Before sorting:");
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }

        myList.Sort();

        Console.WriteLine("After sorting:");
        foreach (var item in myList)
        {
            Console.WriteLine(item);
        }
        
    }
}