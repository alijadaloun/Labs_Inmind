using Lab1.Models.UniversityModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services.UniversityServices;

public class ClassService
{
    private readonly UniversityDbContext _context;

    public ClassService(UniversityDbContext context)
    {
        _context = context;
        
    }

    public List<Class> GetClasses()
    {
        return _context.Classes.ToList();
    }

    public Class GetClass(int id)
    {
        if (_context.Classes.Find(id) == null) throw new Exception("Class Not Found");
        return _context.Classes.Find(id);
    }

    public void AddClass( string teacherName, string courseName, string semester, int year, string room )
    {
        _context.Classes.Add(new Class
        {
            TeacherId = _context.Teachers.FirstOrDefault(x => x.Name == teacherName).TeacherId,
            CourseId = _context.Courses.FirstOrDefault(x => x.Name == courseName).CourseId,
            Semester = semester,
            Year = year,
            Room = room
        });
        _context.SaveChanges();

    }

    public void DeleteClass(int classId)
    {
        if (_context.Classes.Find(classId) == null) throw new Exception("Class Not Found"); 
        _context.Classes.Remove(_context.Classes.Find(classId));
        
    }
}