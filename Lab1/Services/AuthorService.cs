using System.Text.RegularExpressions;
using Lab1.Exceptions;

namespace Lab1.Services;

public class AuthorService
{
    private readonly List<Author> _authors;
    public AuthorService()
    {
        _authors = new List<Author>()
        {
            new Author(1, "J.K. Rowling", "1965-07-31", "United Kingdom"),
    new Author(2, "George Orwell", "1903-06-25", "United Kingdom"),
    new Author(3, "Jane Austen", "1775-12-16", "United Kingdom"),
    new Author(4, "Mark Twain", "1835-11-30", "United States"),
    new Author(5, "Haruki Murakami", "1949-01-12", "Japan"),
    new Author(6, "Aldous Huxley", "1894-07-26", "United Kingdom"),
    new Author(7, "Tennessee Williams", "1911-03-26", "United States"),
    new Author(8, "Emily Brontë", "1818-07-30", "United Kingdom"),
    new Author(9, "Charles Dickens", "1812-02-07", "United Kingdom"),
    new Author(10, "Herman Melville", "1819-08-01", "United States"),
    new Author(11, "Fyodor Dostoevsky", "1821-11-11", "Russia"),
    new Author(12, "J.D. Salinger", "1919-01-01", "United States"),
    new Author(13, "Harper Lee", "1926-04-28", "United States"),
    new Author(14, "William Golding", "1911-09-19", "United Kingdom"),
    new Author(15, "Gabriel García Márquez", "1927-03-06", "Colombia"),
    new Author(16, "Miguel de Cervantes", "1547-09-29", "Spain"),
    new Author(17, "Oscar Wilde", "1854-10-16", "Ireland"),
    new Author(18, "Victor Hugo", "1802-02-26", "France"),
    new Author(19, "F. Scott Fitzgerald", "1896-09-24", "United States"),
    new Author(20, "James Joyce", "1882-02-02", "Ireland"),
    new Author(21, "Toni Morrison", "1931-02-18", "United States"),
    new Author(22, "Tom Wolfe", "1930-03-02", "United States"),
    new Author(23, "J.R.R. Tolkien", "1892-01-03", "United Kingdom"),
    new Author(24, "Leo Tolstoy", "1828-09-09", "Russia"),
    new Author(25, "Fyodor Dostoevsky", "1821-11-11", "Russia"),
    new Author(26, "Bram Stoker", "1847-11-08", "Ireland"),
    new Author(27, "Mary Shelley", "1797-08-30", "United Kingdom"),
    new Author(28, "Charlotte Brontë", "1816-04-21", "United Kingdom"),
    new Author(29, "Homer", "-750-01-01", "Greece"),
    new Author(30, "Ray Bradbury", "1920-08-22", "United States"),
    new Author(31, "Kurt Vonnegut", "1922-11-11", "United States"),
    new Author(32, "Franz Kafka", "1883-07-03", "Austria-Hungary"),
    new Author(33, "Albert Camus", "1913-11-07", "France"),
    new Author(34, "Dante Alighieri", "1265-05-21", "Italy"),
    new Author(35, "Plato", "-428-01-01", "Greece"),
    new Author(36, "Joseph Conrad", "1857-12-03", "United Kingdom"),
    new Author(37, "Ernest Hemingway", "1899-07-21", "United States"),
    new Author(38, "Frank Herbert", "1920-10-08", "United States"),
    new Author(39, "John Steinbeck", "1902-02-27", "United States"),
    new Author(40, "Sylvia Plath", "1932-10-27", "United States"),
    new Author(41, "Anthony Burgess", "1917-02-25", "United Kingdom"),
    new Author(42, "Joseph Heller", "1923-05-01", "United States"),
    new Author(43, "Cormac McCarthy", "1933-07-20", "United States"),
    new Author(44, "Salman Rushdie", "1947-06-19", "United Kingdom"),
    new Author(45, "Mikhail Bulgakov", "1891-05-15", "Russia"),
    new Author(46, "Vladimir Nabokov", "1899-04-22", "Russia"),
    new Author(47, "Ayn Rand", "1905-02-02", "Russia"),
    new Author(48, "William Gibson", "1948-03-17", "United States"),
    new Author(49, "David Mitchell", "1969-01-12", "United Kingdom"),
    new Author(50, "Neil Gaiman", "1960-11-10", "United Kingdom")

        };

    }

    public List<Author> GetAuthorsByBirthDate(string birthDate)
    {
        Regex r = new Regex(@"^\d{4}$");// Enforce 4 decimal numbers only in birthDate
        if (!r.IsMatch(birthDate)) throw new FormatException();
        var query = from author in _authors
            where author.birthDate.Substring(0,4) == birthDate
                select author;

        return query.ToList();
    }

    public List<Author> GetAuthorsByYearAndCountry(string birthDate, string country)
    {
        Regex r = new Regex(@"^\d{4}$");
        if (!r.IsMatch(birthDate)) throw new FormatException();
        var query = from author in _authors
            where author.country == country && author.birthDate.Substring(0,4) == birthDate
                select author;
        return query.ToList();
        
        
    }


}