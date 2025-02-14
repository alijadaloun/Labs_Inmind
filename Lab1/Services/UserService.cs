using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Lab1.Controllers;
using Lab1.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services;

public class UserService
{
    private List<User> users;
    
    public UserService()
    {
     users = new List<User>()
    {
        new User(1, "Alice", "alice@gmail.com"),
        new User(2, "Ali", "a.jad@gmail.com"),
        new User(3, "Kareem", "omar.k@gmail.com"),
        new User(4, "Layla", "layla.h@hotmail.com"),
        new User(5, "Noor", "noor.m@gmail.com"),
        new User(6, "Jacob", "jacob.k@gmail.com"),
        new User(7, "James", "james.z@gmail.com"),
    };
     
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

    public void PostImage( WrapperClass file)
    {
        if (file == null) throw new ArgumentNullException("Upload an image file not null");

        
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