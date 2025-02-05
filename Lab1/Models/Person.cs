namespace Lab1;

public class Person
{
    public long Id { get; set; }
    public string name {get; set; }
    public string email { get; set; }

    public Person()
    {
        
    }
    public Person(long id, string name, string email)
    {
        this.Id = id;
        this.name = name;
        this.email = email;
    }
}