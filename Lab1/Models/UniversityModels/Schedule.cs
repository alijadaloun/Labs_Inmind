namespace Lab1.Models.UniversityModels;

public class Schedule
{
    public int ScheduleId { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public int TeacherId { get; set;}
    public Teacher Teacher { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}