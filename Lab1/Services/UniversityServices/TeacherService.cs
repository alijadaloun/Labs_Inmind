using Lab1.Models.UniversityModels;

namespace Lab1.Services.UniversityServices;

public class TeacherService
{
    private readonly UniversityDbContext _context;

    public TeacherService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Teacher> GetTeachers()
    {
        return _context.Teachers.ToList();
    }

    public Teacher GetTeacher(int teacherid)
    {
        if( _context.Teachers.Find(teacherid) == null)throw new Exception("Teacher not found");
        return _context.Teachers.Find(teacherid);
    }
    public void AddTeacher(string teachername, string password, string phoneNumber)
    {
        var teacher = new Teacher
        {
            TeacherId = _context.Teachers.Max(x => x.TeacherId) + 1,
            Name = teachername,
            password = password,
            email = teachername.ToLower().Replace(' ','_')+"@inmindlab.edu.lb",
            phoneNumber = phoneNumber
        };
        _context.Teachers.Add(teacher);
        _context.SaveChanges();

    }

    public void RemoveTeacher(int id)
    {
        if(_context.Teachers.Find(id) == null) throw new Exception("Teacher not found");
        var teacher = _context.Teachers.Find(id);
        _context.Teachers.Remove(teacher);
        _context.SaveChanges();
        
    }
    
}