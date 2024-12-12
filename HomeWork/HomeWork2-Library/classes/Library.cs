namespace HomeWork2_Library.classes;

public class Library
{
    List<Book> Books;

    public Library()
    {
        Books = GenerateBooks();
    }


    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public Book? BorrowBook(string bookTitle)
    {
        var foundBook = Books.FirstOrDefault(b => b.Title.Contains(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (foundBook != null && foundBook.IsAvailable)
        {
            foundBook.IsAvailable = false;
        }
        else
        {
            Console.WriteLine("Book not found or already was taken!");
            return null;
        }

        return foundBook;
    }

    public void PutBackAllBooks(string bookTitle)
    {
        var foundBook = Books.FirstOrDefault(b => b.Title.Contains(bookTitle, StringComparison.OrdinalIgnoreCase));
        if (foundBook != null)
        {
            foundBook.IsAvailable = true;
        }
        else
        {
            Console.WriteLine("Book not found!");
        }
    }

    public List<Book> SearchByAuthor(string author)
    {
        var foundBooks = Books.FindAll(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        return foundBooks;
    }

    public Book SearchByTitle(string title)
    {
        var foundBook = Books.FirstOrDefault(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        return foundBook;
    }

    public List<Book> SearchByPublisher(string publishingHouse)
    {
        var foundBooks = Books.FindAll(b => b.GetPublishingHouse().Contains(publishingHouse, StringComparison.OrdinalIgnoreCase));
        return foundBooks;
    }

    public Book? ChangePublisherOfBook(string title, string newPublisher)
    {
        var foundBook = SearchByTitle(title);
        if (foundBook != null)
        {
            foundBook.SetPublishingHouse(newPublisher);
        }
        else
        {
            Console.WriteLine("Book not found!");
        }

        return foundBook;
    }

    public void ShowWholeBooksList()
    {
        Console.WriteLine("Here is a books list:");
        for (int i = 0; i < Books.Count; i++)
        {
            Console.WriteLine(
                $"Book {i + 1}: title = '{Books[i].Title}', Author = '{Books[i].Author}', PublishingHouse = '{Books[i].GetPublishingHouse()}', release year = {Books[i].ReleaseYear}, is available to pick = {Books[i].IsAvailable}");
        }
    }

    private List<Book> GenerateBooks()
    {
        var books = new List<Book>
        {
            new Book("The Hobbit", "J.R.R. Tolkien", "George Allen & Unwin", 1937),
            new Book("The Fellowship of the Ring", "J.R.R. Tolkien", "Houghton Mifflin", 1954),
            new Book("The Lion, the Witch, and the Wardrobe", "C.S. Lewis", "Geoffrey Bles", 1950),
            new Book("The Chronicles of Narnia", "C.S. Lewis", "Geoffrey Bles", 1956),
            new Book("Les Misérables", "Victor Hugo", "A. Lacroix, Verboeckhoven & Cie", 1862),
            new Book("The Old Man and the Sea", "Ernest Hemingway", "Charles Scribner's Sons", 1952),
            new Book("Moby-Dick", "Herman Melville", "Harper & Brothers", 1851),
            new Book("The Picture of Dorian Gray", "Oscar Wilde", "Lippincott's Monthly Magazine", 1890),
            new Book("Pride and Prejudice", "Jane Austen", "T. Egerton, Whitehall", 1813),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", "Charles Scribner's Sons", 1925),
            new Book("The Catcher in the Rye", "J.D. Salinger", "Little, Brown and Company", 1951),
            new Book("1984", "George Orwell", "Secker and Warburg", 1949),
            new Book("The Grapes of Wrath", "John Steinbeck", "Viking Press", 1939),
            new Book("One Hundred Years of Solitude", "Gabriel Garcia Marquez", "Harper & Row", 1967),
            new Book("In Search of Lost Time", "Marcel Proust", "Grasset", 1913),
            new Book("The Road Less Traveled", "M. Scott Peck", "Simon & Schuster", 1978),
            new Book("Boundaries", "Dr. Henry Cloud", "Zondervan", 1992),
            new Book("The Divine Comedy", "Dante Alighieri", "Various", 1320),
            new Book("The Art of War", "Sun Tzu", "Various", -500),
            new Book("The Trial", "Franz Kafka", "Schocken Verlag", 1914),
            new Book("Ulysses", "James Joyce", "Sylvia Beach", 1922),
            new Book("Don Quixote", "Miguel de Cervantes", "Francisco de Robles", 1605),
            new Book("The Road Less Traveled", "M. Scott Peck", "Simon & Schuster", 1978),
            new Book("The Catcher in the Rye", "J.D. Salinger", "Little, Brown and Company", 1951),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", "Charles Scribner's Sons", 1925),
            new Book("The Lord Of the Ring", "J.R.R. Tolkien", "George Allen & Unwin", 1937),
            new Book("The Chronicles of Narnia", "C.S. Lewis", "Geoffrey Bles", 1956),
            new Book("Brave New World", "Aldous Huxley", "Chatto & Windus", 1932),
            new Book("The Catcher in the Rye", "J.D. Salinger", "Little, Brown and Company", 1951),
            new Book("The Old Man and the Sea", "Ernest Hemingway", "Charles Scribner's Sons", 1952),
            new Book("The Picture of Dorian Gray", "Oscar Wilde", "Lippincott's Monthly Magazine", 1890),
            new Book("Catch-22", "Joseph Heller", "Simon & Schuster", 1961),
            new Book("The Road to Serfdom", "Friedrich Hayek", "University of Chicago Press", 1944),
            new Book("On the Origin of Species", "Charles Darwin", "John Murray", 1859),
            new Book("Brave New World", "Aldous Huxley", "Chatto & Windus", 1932),
            new Book("The Divine Comedy", "Dante Alighieri", "Various", 1320),
            new Book("Fahrenheit 451", "Ray Bradbury", "Ballantine Books", 1953),
            new Book("The Secret Garden", "Frances Hodgson Burnett", "Frederick A. Stokes", 1911),
            new Book("Sapiens: A Brief History of Humankind", "Yuval Noah Harari", "Harvill Secker", 2011),
            new Book("The Art of War", "Sun Tzu", "Various", -500),
            new Book("The Little Prince", "Antoine de Saint-Exupéry", "Reynal & Hitchcock", 1943),
            new Book("A Tale of Two Cities", "Charles Dickens", "Chapman & Hall", 1859)
        };
        return books;
    }
}