using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/university/[controller]")]
public class CourseController:ControllerBase
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("getall")]
    public IActionResult GetCourses()
    {
        return Ok(_courseService.GetCourses());
    }
    [HttpGet("get")]
    public IActionResult GetCourseById(int courseId)
    {
        return Ok(_courseService.GetCourseById(courseId));
    }
    [HttpPost("add")]
    public IActionResult AddCourse(string courseName,string departmentName)
    {
        _courseService.AddCourse(courseName, departmentName);
        return Ok($"{courseName} added successfully to courses");
    }
    [HttpDelete("delete")]
    public IActionResult RemoveCourse(int classId)
    {
        _courseService.RemoveCourse(classId);
        return Ok("Class removed from courses");
    }
    
}