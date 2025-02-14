using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/university/[controller]")]
public class ClassController:ControllerBase
{
    private readonly ClassService _classService;

    public ClassController(ClassService classService)
    {
        _classService = classService;
    }
    [HttpGet("getall")]
    public IActionResult GetClasses()
    {
        return Ok(_classService.GetClasses());
    }
    [HttpGet("get")]
    public IActionResult GetClass(int id)
    {
        return Ok(_classService.GetClass(id));
        
    }
    [HttpPost("add")]
    public IActionResult AddClass(string teacherName, string courseName, string semester, int year, string room)
    {
        _classService.AddClass(teacherName, courseName, semester, year, room);
        return Ok("Class Added Successfully");
    }
    [HttpDelete("delete")]

    public IActionResult DeleteClass(int classId)
    {
        _classService.DeleteClass(classId);
        return Ok("Class Deleted Successfully");
    }
    
}