using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/[controller]")]
public class AdminController:ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpGet("users")]
    [Authorize(Roles = "admin")]
    public IActionResult GetAll()
    {
        return Ok(_adminService.GetUsers());
    }
    
    [HttpGet("users/{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult GetUser(int id)
    {
        return Ok(_adminService.GetUser(id));
    }
    [HttpGet("students")]
    [Authorize(Roles = "admin")]
    public IActionResult GetAllStudents()
    {
        return Ok(_adminService.GetStudents());
    }
    [HttpGet("students/{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult GetStudent(int id)
    {
        return Ok(_adminService.GetStudent(id));
    }
    [HttpGet("teachers")]
    [Authorize(Roles = "admin")]
    public IActionResult GetAllTeachers()
    {
        return Ok(_adminService.GetTeachers());
    }
    [HttpGet("teachers/{id}")]
    [Authorize(Roles = "admin")]
    public IActionResult GetAllTeachers(int id)
    {
        return Ok(_adminService.GetTeacher(id));
    }
    
    
}