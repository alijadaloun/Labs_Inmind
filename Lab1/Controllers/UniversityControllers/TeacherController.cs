using AutoMapper;
using Lab1.Models.UniversityModels;
using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/university/[controller]")]
public class TeacherController:ControllerBase
{
    private readonly TeacherService _teacherService;
    private readonly IMapper _mapper;

    public TeacherController(TeacherService teacherService, IMapper mapper)
    {
        _teacherService = teacherService;
        _mapper = mapper;
    }

    [HttpGet("getall")]
    public IActionResult GetAllTeachers()
    {
        var teachers = _teacherService.GetTeachers();
        var teacherView = _mapper.Map<List<TeacherViewModel>>(teachers);
        return Ok(teacherView);
    }

    [HttpGet("get")]
    public IActionResult GetTeacher(int teacherid)
    {
        var teacher = _teacherService.GetTeacher(teacherid);
        if (teacher == null) return NotFound();
        var teacherView = _mapper.Map<TeacherViewModel>(_teacherService.GetTeacher(teacherid));
        return Ok(teacherView);
    }

    [HttpPost("add")]
    public IActionResult AddTeacher(string name,string password, string phoneNumber)
    {
        _teacherService.AddTeacher(name, password, phoneNumber);
        return Ok("Teacher added successfully");

    }

    [HttpDelete("delete")]
    public IActionResult DeleteTeacher(int id)
    {
        _teacherService.RemoveTeacher(id);
        return Ok("Teacher deleted successfully");
    }
    
}