namespace Lab1.Models.UniversityModels;

public class Class {
    public int ClassId { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string Semester { get; set; }
    public int Year { get; set; }
    public string Room { get; set; }
    

}