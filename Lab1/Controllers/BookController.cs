using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Lab1.Controllers;

public class BookController:ODataController
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [EnableQuery]
    public IQueryable<Book>Get()
    {
        return _bookService.GetBooks();

    }
    // ODATA QUERIES:
    // -Retrieve books on published year, ordered by release data ascending:
    // /odata/Books?$filter=published_year eq 2025&$orderby=published_year asc
    // -Retrieve books on published year, ordered by release data desccending:
    // /odata/Books?$filter=published_year eq 2025&$orderby=published_year desc
    // -Total Number of books:
    // /odata/Books?$count
    // -Retreive specific number of books(using Pagination):
    // /odata/Books?$skip=5$top=5

}