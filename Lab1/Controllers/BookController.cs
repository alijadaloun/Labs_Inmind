using Lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;

[ApiController]
[Route("api/books")]
public class BookController : ControllerBase
{
   private readonly  BookService _bookService;
    public BookController( BookService bookService )
    {
        _bookService = bookService;
    }

    [HttpGet("byYear/{year}")]
    public IActionResult GetBookByYear(int year, bool orderASC)
    {
        var books = _bookService.GetBooksByYear( year , orderASC);
        return Ok(books);

    }
    [HttpGet("count")]
    public IActionResult GetBookCount()
    {
        var count = _bookService.GetBooksCount();
        return Ok(count);
    }

    [HttpGet("getbook/record/{pageNumber}/{pageSize}")]
    public IActionResult GetBookRecord(int pageNumber, int pageSize)
    {
        var books = _bookService.GetBookRecord(pageSize, pageNumber);
        return Ok(books);
        
    }


}