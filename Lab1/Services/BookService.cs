using System.Data;
using System.Linq;
using Lab1.Exceptions;

namespace Lab1.Services;


public class BookService
{
    private readonly List<Book> _books;

    public BookService()
    {
        _books = new List<Book>()
        {
            new Book(1, "Harry Potter and the", 1, "9780439708180", 1997),
            new Book(2, "Star Wars", 2, "9780451524935", 1949),
            new Book(3, "Animal Farm", 2, "9780451526342", 1945),
            new Book(4, "Pride and Prejudice", 3, "9781503290563", 1813),
            new Book(5, "The Adventures of To", 4, "9780486400778", 1876),
            new Book(6, "Norwegian Wood", 5, "9780375704024", 1987),
            new Book(7, "Brave New World", 6, "9780060850524", 1945),
            new Book(8, "The Glass Menagerie", 7, "9780811214049", 1945),
            new Book(9, "Sense and Sensibility", 3, "9780486290492", 1813), 
            new Book(10, "Wuthering Heights", 8, "9780141439556", 1847), 
            new Book(11, "Great Expectations", 9, "9780141439563", 1861),
            new Book(12, "Moby-Dick", 10, "9781503280786", 1851),
            new Book(13, "Crime and Punishment", 11, "9780486415871", 1866),
            new Book(14, "The Catcher in the Rye", 12, "9780316769488", 1951),
            new Book(15, "To Kill a Mockingbird", 13, "9780061120084", 1960),
            new Book(16, "Lord of the Flies", 14, "9780399501487", 1954),
            new Book(17, "One Hundred Years of Solitude", 15, "9780060883287", 1967),
            new Book(18, "Don Quixote", 16, "9780060934347", 1605),
            new Book(19, "The Picture of Dorian Gray", 17, "9780141439570", 1890),
            new Book(20, "Les Misérables", 18, "9780140444308", 1862),
            new Book(21, "The Great Gatsby", 19, "9780743273565", 1925),
            new Book(22, "Ulysses", 20, "9780199535675", 1922),
            new Book(23, "Beloved", 21, "9781400033416", 1987), 
            new Book(24, "The Bonfire of the Vanities", 22, "9780312427573", 1987), 
            new Book(25, "The Hobbit", 23, "9780345339683", 1937),
            new Book(26, "War and Peace", 24, "9781400079988", 1869),
            new Book(27, "The Brothers Karamazov", 25, "9780374528379", 1880),
            new Book(28, "Dracula", 26, "9780486411095", 1897),
            new Book(29, "Frankenstein", 27, "9780486282114", 1818),
            new Book(30, "Jane Eyre", 28, "9780141441146", 1847),
            new Book(31, "The Iliad", 29, "9780140275360", 750),
            new Book(32, "The Odyssey", 29, "9780140268867", 700),
            new Book(33, "Fahrenheit 451", 30, "9781451673319", 1953),
            new Book(34, "Slaughterhouse-Five", 31, "9780385333849", 1969),
            new Book(35, "The Metamorphosis", 32, "9780486290300", 1915),
            new Book(36, "The Stranger", 33, "9780679720201", 1942),
            new Book(37, "The Divine Comedy", 34, "9780142437223", 1320),
            new Book(38, "The Republic", 35, "9780141442433", 380),
            new Book(39, "Heart of Darkness", 36, "9780486264646", 1899),
            new Book(40, "The Old Man and The Sea", 37, "9780684801223", 1952),
            new Book(41, "Dune", 38, "9780441013593", 1965),
            new Book(42, "Brave New World Revisited", 6, "9780060898526", 1958),
            new Book(43, "The Grapes of Wrath", 39, "9780143039433", 1939),
            new Book(44, "The Sun Also Rises", 37, "9780743297332", 1926),
            new Book(45, "The Bell Jar", 40, "9780060837020", 1963),
            new Book(46, "A Clockwork Orange", 41, "9780393312835", 1962),
            new Book(47, "The Catch-22", 42, "9781451626650", 1961),
            new Book(48, "The Lord of the Rings", 23, "9780618640157", 1954),
            new Book(49, "The Road", 43, "9780307387899", 2006),
            new Book(50, "A Tale of Two Cities", 9, "9780141439600", 1859),
            new Book(51, "East of Eden", 39, "9780140186390", 1952),
            new Book(52, "Midnight’s Children", 44, "9780812976533", 1981),
            new Book(53, "The Master and Margarita", 45, "9780679760801", 1967),
            new Book(54, "Lolita", 46, "9780679723165", 1955),
            new Book(55, "Atlas Shrugged", 47, "9780451191144", 1957),
            new Book(56, "Neuromancer", 48, "9780441569595", 1984),
            new Book(57, "Cloud Atlas", 49, "9780375507250", 2004),
            new Book(58, "American Gods", 50, "9780062572233", 2001)

        };
    }
        public List<Book> GetBooksByYear(int year, Boolean orderAsc)
        {
            if (year < 1 || year > 9999) throw new YearNotValidException();
            IOrderedEnumerable<Book> query;
            if (orderAsc)
            {
                query = from book in _books
                    where book.PublishedYear == year orderby book.BookId ascending
                    select book;

            }
            else
            {
                query = from book in _books
                    where book.PublishedYear == year orderby book.BookId descending 
                    select book;
            }

            return query.ToList();

        }
        public int GetBooksCount()
        {
            int count = (from book in _books
                select book).Count();
            return count;
        }

        public List<Book> GetBookRecord(int pageSize, int pageNumber )
        {
            //to start page index at 1:
            if (pageSize < 1 || pageNumber < 1) throw new PageOutOfRangeException();
           var query = (from book in _books
                orderby book.BookId ascending 
                select book).Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            
            
            return query;
        }
}