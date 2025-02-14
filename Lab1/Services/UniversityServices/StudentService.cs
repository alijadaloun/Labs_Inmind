using Lab1.Models.UniversityModels;

namespace Lab1.Services.UniversityServices;

public class StudentService
{
    private readonly UniversityDbContext _context;

    public StudentService(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Student> GetStudents()
    {
        List<Student> students = _context.Students.ToList();
        return students;
    }

    public Student GetStudentById(int id)
    {
        if(id<1 || _context.Students.Find(id) == null)throw new Exception("Student Not Found");
        var student = _context.Students.Find(id);
        return student;
    }

    public void AddStudent(string studentName, string password, string phoneNumber, string date)
    {
        
        Student student = new Student
        {
            StudentId = _context.Students.Max(x => x.StudentId) + 1,
            Name = studentName,
            password = password,
            phoneNumber = phoneNumber,
            birthdate = DateOnly.Parse(date)
        };
        _context.Students.Add(student);
        _context.SaveChanges();
        
    }

    public void UpdateStudent(int id, string newStudentName, string newEmail)
    {
        if(_context.Students.Find(id) == null)throw new Exception("Student Not Found");
        Student student = _context.Students.Find(id);
        student.Name = newStudentName;
        student.email = newEmail;
        _context.SaveChanges();
    }
}