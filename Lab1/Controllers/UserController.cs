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
    try
    {
        return Ok(_userService.GetUserById(id));
    }
    catch (UserNotFoundException ex)
    {
        return StatusCode(300, "User does not exist");

    }
    catch (Exception ex)
    {
        return StatusCode(500, "Server Error");
      
    }
}

[HttpGet("name")]
public IActionResult GetUsersByName([FromQuery] string filter)
{
    try
    {
        var users = _userService.GetUsersByName(filter);
        return Ok(users);
    }
    catch (UserNotFoundException ex)
    {
        return StatusCode(300, "User does not exist");
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Server Error");
    }
}

[HttpGet("date")]
public IActionResult GetDate([FromHeader(Name = "Accept-Language")] string header)
{
    try
    {
        var date = _userService.GetDate(header);
        return Ok(date);
    }
    catch (ArgumentNullException ex)
    {
        return StatusCode(300, ex.Message);
    }
    catch ( Exception ex)
    {
        return StatusCode(500, "Server Error");
    }
}


[HttpPost("updateUser/{id}")]
public IActionResult UpdateUser(long id, string newName, string email)
{
    try
    {
        _userService.UpdateUser(id, newName, email);
        return Ok($"User of id {id} updated");
    }
    catch (UserExistException ex)
    {
        return StatusCode(300, ex.Message);
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Server Error");
    }
}

[HttpPost("postimg")] 
public IActionResult PostImage( IFormFile file)
{
    try
    {
        return Ok( "File posted successfully" );
    }
    catch (ArgumentException ex)
    {
        return StatusCode(300, "Invalid image");
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { error = $"Internal Server Error{ex.Message}" });
    }

}

[HttpPost("deleteUser/{id}")]
public IActionResult DeleteUser(long id)
{
    try
    {
        _userService.DeleteUser(id);
        return Ok( $"user of id {id} deleted" );
    }
    catch (UserNotFoundException ex)
    {
        return StatusCode(300,$"User of id {id} does not exist");
    }
}

}