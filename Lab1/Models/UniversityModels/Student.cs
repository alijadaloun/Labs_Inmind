using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models.UniversityModels;

public class Student
{

    public int StudentId { get; set; }
    public string Name { get; set; }
    public string email { get; set; }
    public DateOnly birthdate { get; set; }
    public string password { get; set; }
    public string phoneNumber { get; set; }
}