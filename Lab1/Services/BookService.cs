using System.Data;
using System.Linq;
using Lab1.Exceptions;
using Lab1.Models;

namespace Lab1.Services;


public class BookService
{
    private readonly LibrarydbContext _context;

    public BookService( LibrarydbContext context )
    {
        _context = context;

    }

    public IQueryable<Book> GetBooks()
    {
        return _context.Books.ToList().AsQueryable();
        
    }

}