namespace Lab1.Models.UniversityModels;

public class User
{
    public long Id { get; set; }
    public string name {get; set; }
    public string email { get; set; }

    public User(long id, string name, string email)
    {
        this.Id = id;
        this.name = name;
        this.email = email;
    }
}