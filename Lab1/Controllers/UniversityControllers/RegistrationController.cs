using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/university/[controller]")]
public class RegistrationController:ControllerBase
{
    private readonly RegistrationService _registrationService;

    public RegistrationController(RegistrationService registrationService)
    {
        _registrationService = registrationService;
    }
    [HttpGet("getall")]
    public IActionResult GetRegistrations()
    {
        return Ok(_registrationService.GetRegistrations());
    }
    [HttpPost("enroll")]
    public IActionResult EnrollInCourse(int studentid, int courseid)
    {
        _registrationService.EnrollInCourse(studentid, courseid);
        return Ok($"Student of id: {studentid} successfully enrolled in course of id: {courseid}");
    }
    
}