namespace HomeWork_3_LINQ;

public class Book
{
    public Book(string title, string author, string genre, DateTime promotionDate)
    {
        Title = title;
        Author = author;
        Genre = genre;
        PromotionDate = promotionDate;
    }

    public string? Title { get; }
    public string? Author { get; }
    public string? Genre { get; }
    public DateTime PromotionDate { get; }
}