namespace Lab1;

public class Author
{
    public int AuthorId { get; set; }
    public string name { get; set; }
    public string birthDate { get; set; }
    public  string country { get; set; }

    public Author( int AuthorId, string name, string birthDate, string country)
    {
        this.AuthorId = AuthorId;
        this.name = name;
        this.birthDate = birthDate;
        this.country = country;
    }
}