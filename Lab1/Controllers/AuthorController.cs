using Lab1.Models;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Lab1.Controllers;
public class AuthorController: ODataController
{
    private readonly AuthorService _authorService;
    public AuthorController( AuthorService authorService )
    {
        _authorService = authorService;
    }
    
    [EnableQuery]
    [HttpGet]
    public IQueryable<Author> Get()
    {
        return _authorService.GetAuthors();
    }
    //ODATA AUTHOR QUERIES:
    // -Authors Born In same year:
    // /odata/Authors?$apply=groupby((birth_date))
    //  -Authors Born In same year and country:
    // /odata/Authors?$apply=groupby((birth_date,country))
    
   
    
    

}