namespace HomeWork2_Library.classes;

public class Book(string title, string author, string publishingHouse, int releaseYear)
{
    private string _publishingHouse = publishingHouse;
    
    public string Title { get; init; } = title;
    public string Author { get; init; } = author;

    public string GetPublishingHouse()
    {
        return _publishingHouse;
    }
    public void SetPublishingHouse(string newPublishingHouse)
    {
        _publishingHouse = newPublishingHouse;
    }
    public int ReleaseYear { get; init; } = releaseYear;
    public bool IsAvailable { get; set; } = true;

    
}