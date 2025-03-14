namespace Lab1;

public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public string ISBN { get; set; }
    public int PublishedYear { get; set; }
    public Author Author { get; set; }
    public Book( int BookId, string Title, int AuthorId, string ISBN, int PublishedYear )
    {
        this.BookId = BookId;
        this.Title = Title;
        this.AuthorId = AuthorId;
        this.ISBN = ISBN;
        this.PublishedYear = PublishedYear;
        
        
    }
}