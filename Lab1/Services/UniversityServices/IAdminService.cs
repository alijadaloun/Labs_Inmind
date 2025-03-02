using Lab1.Models.UniversityModels;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services.UniversityServices;

public interface IAdminService
{
    public List<User> GetUsers();
    public User GetUser(int id);
    public List<Student> GetStudents();
    public Student GetStudent(int id);
    public List<Teacher> GetTeachers();
    public Teacher GetTeacher(int id);
}