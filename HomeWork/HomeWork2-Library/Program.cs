using HomeWork2_Library.classes;

namespace HomeWork2_Library;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Home Work 2 Library!");

        var library = new Library();
        library.AddBook(new Book("Fight between Ainures", "Kovalchuk", "Sun publisher", 2034));
        library.BorrowBook("Hobbit");
        var b1 = library.SearchByTitle("Hobbit");
        var b2 = library.SearchByTitle("Ainures");
        library.BorrowBook("Hobbit");
        library.BorrowBook("Ainures");
        Console.WriteLine($"{b1.Title} is available  {b2.IsAvailable}");
        Console.WriteLine($"{b2.Title} is available  {b2.IsAvailable}");
        
        library.PutBackAllBooks("Ainures");
        Console.WriteLine($"{b2.Title} was put back {b2.IsAvailable}");
        var tolkien = library.SearchByAuthor("Tolkien");
        for (int i = 0; i < tolkien.Count; i++)
        {
            Console.WriteLine(
                $"Book {i + 1}: title = '{tolkien[i].Title}', Author = '{tolkien[i].Author}', PublishingHouse = '{tolkien[i].GetPublishingHouse()}', release year = {tolkien[i].ReleaseYear}, is available to pick = {tolkien[i].IsAvailable}");
        }

        var publisher = library.SearchByPublisher("Geoffrey");
        for (int i = 0; i < tolkien.Count; i++)
        {
            Console.WriteLine(
                $"Book {i + 1}: title = '{publisher[i]?.Title}', Author = '{publisher[i]?.Author}', PublishingHouse = '{publisher[i]?.GetPublishingHouse()}', release year = {publisher[i]?.ReleaseYear}, is available to pick = {publisher[i]?.IsAvailable}");
        }
        library.ChangePublisherOfBook("Ainures", "Oleksander Manve");

        library.ShowWholeBooksList();
    }
}