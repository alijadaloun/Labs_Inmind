namespace Lab1;

public class Student
{
    public long Id { get; set; }
    public string name {get; set; }
    public string email { get; set; }

    public Student()
    {
    }

    public Student(long id, string name, string email) 
    {
        this.Id = id;
        this.name = name;
        this.email = email;
    }
    
    
}