using Lab1.Models.UniversityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Services.UniversityServices;

public class AdminService: IAdminService
{
    private readonly UniversityDbContext _context;
    private readonly StudentService _studentService;
    private readonly TeacherService _teacherService;
    private readonly UserService _userService;

    public AdminService(UniversityDbContext context, StudentService studentService, TeacherService teacherService, UserService userService)
    {
        _context = context;
        _studentService = studentService;
        _teacherService = teacherService;
        _userService = userService;
    }
    
    public  List<User> GetUsers()
    {
        return _userService.GetUsers();

    }

    public User GetUser(int id)
    {
        return _userService.GetUserById(id);
    }

    public List<Student> GetStudents()
    {
        return _studentService.GetStudents();
    }

    public Student GetStudent(int id)
    {
        return _studentService.GetStudentById(id);
    }

    public List<Teacher> GetTeachers()
    {
        return _teacherService.GetTeachers();
    }

    public Teacher GetTeacher(int id)
    { 
        return _teacherService.GetTeacher(id);
    }
}