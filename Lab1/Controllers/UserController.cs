using Lab1.Exceptions;
using Lab1.Filters;
using Lab1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;
[ApiController]
[Route("api/users")]//the base url for all endpoints
[ServiceFilter(typeof(LoggingActionFilter))]
public class UserController: ControllerBase
{
    
private readonly UserService _userService;

public UserController(UserService userService)
{
    _userService = userService;
}

[HttpGet("allusers")]
public IActionResult GetUsers()
{
    
    return Ok(_userService.GetUsers());
}

[HttpGet("user/{id}")]
public IActionResult GetUserById(long id)
{
        return Ok(_userService.GetUserById(id));
}

[HttpGet("name")]
public IActionResult GetUsersByName([FromQuery] string filter)
{
        var users = _userService.GetUsersByName(filter);
        return Ok(users);
    

}

[HttpGet("date")]
public IActionResult GetDate([FromHeader(Name = "Accept-Language")] string header)
{

        var date = _userService.GetDate(header);
        return Ok(date);

}


[HttpPost("updateUser/{id}")]
public IActionResult UpdateUser(long id, string newName, string email)
{
    
        _userService.UpdateUser(id, newName, email);
        return Ok($"User of id {id} updated");
    
}

[HttpPost("postimg")] 
public IActionResult PostImage( IFormFile file)
{

        return Ok( "File posted successfully" );


}

[HttpPost("deleteUser/{id}")]
public IActionResult DeleteUser(long id)
{
   
        _userService.DeleteUser(id);
        return Ok( $"user of id {id} deleted" );
    
}

}