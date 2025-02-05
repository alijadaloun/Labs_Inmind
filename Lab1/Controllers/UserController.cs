using Lab1.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers;
[ApiController]
[Route("api/users")]//the base url for all endpoints
public class UserController: ControllerBase
{
    
private readonly UserService _userService;

public UserController(UserService userService)
{
    this._userService = userService?? throw new ArgumentNullException(nameof(userService));
}

[HttpGet("user")]
public List<User> GetUsers()
    =>_userService.GetUsers();

[HttpGet("user/{id}")]
public User GetUserById(long id)
    =>_userService.GetUserById(id);

[HttpGet("name")]
public List<User> GetUsersByName([FromQuery] string filter)
{
    var users   = _userService.GetUsersByName(filter);
    return users;
}

[HttpGet("date")]
public string GetDate([FromHeader(Name = "Accept-Language")]string header)
{
    if (string.IsNullOrEmpty(header)) return "Header is required";
    var date = _userService.GetDate(header);
    return date;
}


[HttpPost("updateUser/{id}")]
public IActionResult UpdateUser(long id, string newName, string email)
{
    try
    {
        _userService.UpdateUser(id, newName, email);
        return Ok(new { message = "user updated" });
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

[HttpPost("postimg")] 
public IActionResult PostImage( IFormFile file)
{
    try
    {

        string filePath = _userService.PostImage(file);
        string fileUrl = $"{Request.Scheme}://{Request.Host}{filePath}";
        return Ok(new { message = "File posted successfully", fileUrl });
    }
    catch (ArgumentException ex)
    {
        return BadRequest(new { error = ex.Message  });
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
        return Ok(new { message = "user deleted" });
    }
    catch (Exception ex)
    {
        return BadRequest(new { message = ex.Message });
    }
}

}