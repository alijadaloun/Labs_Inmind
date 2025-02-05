using Lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;
[ApiController]
[Route("api/authors")]
public class AuthorController: ControllerBase
{
    private readonly AuthorService _authorService;
    public AuthorController( AuthorService authorService )
    {
        _authorService = authorService;
    }

    [HttpGet("authorYear")]
    public IActionResult GetAuthorByYear(string birthDate)
    {
        var authors = _authorService.GetAuthorsByBirthDate(birthDate);
        return Ok(authors);
    }
    [HttpGet("authorByYearAndCountry")]
    public IActionResult GetAuthorsByYearAndCountry(string birthDate, string country)
    {
        var authors = _authorService.GetAuthorsByYearAndCountry(birthDate, country);
        return Ok(authors);
    }
    
    

}