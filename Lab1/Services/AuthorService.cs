using System.Text.RegularExpressions;
using Lab1.Exceptions;
using Lab1.Models;

namespace Lab1.Services;

public class AuthorService
{
    private readonly LibrarydbContext _context;
    
    public AuthorService(LibrarydbContext context)
    {
        _context = context;
        
    }

    public IQueryable<Author> GetAuthors()
    {
        return _context.Authors.AsQueryable();
    }
    




}