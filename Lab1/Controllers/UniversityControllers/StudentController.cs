using AutoMapper;
using Lab1.Models.UniversityModels;
using Lab1.Services.UniversityServices;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers.UniversityControllers;
[ApiController]
[Route("api/university/[controller]")]
public class StudentController: ControllerBase
{
    private readonly StudentService _studentService;
    private readonly IMapper _mapper;

    public StudentController(StudentService studentService, IMapper mapper)
    {
        _studentService = studentService;
        _mapper = mapper;
    }
    [HttpGet("getall")]
    public IActionResult GetStudents()
    {
        var students = _studentService.GetStudents();
        var studentView = _mapper.Map<List<StudentViewModel>>(students);
        return Ok(studentView);
    }
    [HttpGet("get")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentService.GetStudentById(id);
        if (student == null) return NotFound();
        var studentview = _mapper.Map<StudentViewModel>(student);
        return Ok(studentview);
    }

    [HttpPost("add")]
    public IActionResult AddStudent(string studentName, string password, string phoneNumber,string birthdate)
    {
        _studentService.AddStudent(studentName, password, phoneNumber, birthdate);
        return Ok($"{studentName} added successfully");
        
    }

    [HttpPut("update")]
    public IActionResult UpdateStudent(int id, string newName, string newEmail)
    {
        _studentService.UpdateStudent(id, newName, newEmail);
        return Ok($"Student of id: {id} name was updated to: {newName} successfully");
    }
    

}