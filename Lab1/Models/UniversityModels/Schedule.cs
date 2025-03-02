namespace Lab1.Models.UniversityModels;

public class Schedule
{
    public int ScheduleId { get; set; }
    public int ClassId { get; set; }

    public int TeacherId { get; set;}

    public int CourseId { get; set; }

    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
}