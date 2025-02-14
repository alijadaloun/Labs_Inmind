using Lab1.Models.UniversityModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services.UniversityServices;

public class RegistrationService
{
    private readonly UniversityDbContext _context;
    public RegistrationService( UniversityDbContext context)
    {
        _context = context;
    }

    public List<Registration> GetRegistrations()
    {
        return _context.Registrations.ToList();
    }

    public void EnrollInCourse(int studentid, int courseid)
    { 
        if (_context.Courses.Find(courseid) == null) throw new Exception("Course Not Found");
        _context.Registrations.Add(new Registration
        {
            RegistrationId = _context.Registrations.Max(r=>r.RegistrationId)+1,
            Date = DateOnly.FromDateTime(DateTime.Now),
            StudentId = studentid,
            CourseId = courseid
        });

    }
}