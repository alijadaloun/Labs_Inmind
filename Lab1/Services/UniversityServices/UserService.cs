using System.Globalization;
using Lab1.Controllers;
using Lab1.Exceptions;
using Lab1.Models.UniversityModels;

namespace Lab1.Services.UniversityServices;

public class UserService
{
    private List<User> users;
    private readonly UniversityDbContext _context;
    
    public UserService( UniversityDbContext context )
    {
        _context = context;
     users = _context.Users.ToList();
     
}

public List<User> GetUsers()
    {
        return this.users;
    }

    public User GetUserById( long id)
    {
        if (!users.Exists(x => x.Id == id))
        {
            throw new UserNotFoundException();
        }

        return users.Find(user => user.Id == id);
    }

    public List<User> GetUsersByName(string name)
    {
        if (!users.Exists(x => x.name == name))
        {
            throw new UserNotFoundException();
        }
        return users.Where(user => user.name.Contains(name,StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public string GetDate(string culture)
    {
        if (string.IsNullOrEmpty(culture))
        {
            throw new ArgumentNullException(culture);
        }
        var cultureInfo = new CultureInfo(culture);
        return DateTime.UtcNow.ToString("D",cultureInfo);
        
    }

    public void UpdateUser(long id, string newname, string email)
    {
        if (!users.Exists(x => x.Id == id))
        {
            throw new UserExistException();
        }
        var user = users.Find(user => user.Id == id);
        if (user == null) return;
        user.name = newname;
        user.email = email;
    }



    public void DeleteUser(long id)
    {
        if (!users.Exists(x => x.Id == id))
        {
            throw new UserNotFoundException();
        }
        User user = users.Find(user => user.Id == id);
        if(user == null) return;
        users.Remove(user);

    }



}