namespace Lab1.Models.UniversityModels;

public class Registration
{
    public int RegistrationId { get; set; }
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly Date { get; set; }
    
}