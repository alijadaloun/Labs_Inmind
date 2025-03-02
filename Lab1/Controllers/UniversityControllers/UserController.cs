using Azure.Storage.Blobs;
using Lab1.Filters;
using Lab1.Services;
using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/users")]//the base url for all endpoints
[ServiceFilter(typeof(LoggingActionFilter))]
public class UserController: ControllerBase
{
private readonly UserService _userService;
private readonly IWebHostEnvironment _webHostEnvironment;
private readonly BlobStorageService _blobStorageService;

public UserController(UserService userService, IWebHostEnvironment webHostEnvironment, BlobStorageService blobStorageService)
{
    _userService = userService;
    _webHostEnvironment = webHostEnvironment;
    _blobStorageService = blobStorageService;
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
public IActionResult PostImage([FromForm] WrapperClass file)
{
        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        string uniquepath = Guid.NewGuid().ToString() + Path.GetExtension(file.File.FileName);
        string filePath = Path.Combine(uploadDir, uniquepath);
        using (var stream = new FileStream(filePath, FileMode.Create))
        { 
                file.File.CopyTo(stream);
        }
        
        return Ok( "File posted successfully" );
}

[HttpDelete("deleteUser/{id}")]
public IActionResult DeleteUser(long id)
{
        
   
        _userService.DeleteUser(id);
        return Ok( $"user of id {id} deleted" );
    
}
[HttpPost("uploadimg")]
public async Task<IActionResult> UploadUserImage(IFormFile file)
{
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

        using (var stream = file.OpenReadStream())
        {
                var fileUrl = await _blobStorageService.UploadFileAsync(stream, fileName);
                return Ok("File uploaded successfully");
        }
}

[HttpDelete("deleteimg")]
public async Task<IActionResult> DeleteUserImage(string fileName)
{
        var isDeleted = await _blobStorageService.DeleteFileAsync(fileName);
        if (!isDeleted)
        {
                return NotFound("File not found.");
        }

        return Ok("File deleted successfully.");
}

}

public class WrapperClass
{
        public IFormFile File { get; set; }
        // this is used because swagger could not run the app while fromform is used with iformfile

}