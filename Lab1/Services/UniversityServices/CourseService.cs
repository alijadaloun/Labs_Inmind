using System.Globalization;
using Lab1.Models.UniversityModels;
using Lab1.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services.UniversityServices;

public class CourseService
{
    private readonly UniversityDbContext _context;

    public CourseService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Course> GetCourses()
    {
        return _context.Courses.ToList();
    }

    public Course GetCourseById(int courseId)
    {
        if( _context.Courses.Find(courseId) == null) throw new Exception("Course Not Found");
        return _context.Courses.Find(courseId);
    }

    public void AddCourse(string courseName,string departmentName)
    {
        _context.Courses.Add(new Course
        {
            CourseId = _context.Courses.Max(c=>c.CourseId)+1,
            Name = courseName,
            Department = departmentName
            
        });
        _context.SaveChanges();

    }
    public void RemoveCourse(int courseId)
    {
        if (_context.Courses.Find(courseId) == null) throw new Exception("Course Not Found");
        _context.Courses.Remove(_context.Courses.Find(courseId));
        _context.SaveChanges();
    }
}