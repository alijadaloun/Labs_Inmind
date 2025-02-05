using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Services;

public class UserService
{
    private List<User> users;
    private IWebHostEnvironment _webHostEnvironment;
    public UserService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        
        

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

    public User? GetUserById( long id)
    {
    return users.Find(user => user.Id == id);
    }

    public List<User> GetUsersByName(string name)
    {
        return users.Where(user => user.name.Contains(name,StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public string GetDate(string culture)
    {
        try
        {
            var cultureInfo = new CultureInfo(culture);
            return DateTime.UtcNow.ToString("D",cultureInfo);
        }
        catch (CultureNotFoundException)
        {
        
            var cultureInfo = new CultureInfo("en-US");
            return DateTime.UtcNow.ToString("D",cultureInfo);
        }

    }

    public void UpdateUser(long id, string newname, string email)
    {
        var user = users.Find(user => user.Id == id);
        if (user == null) return;
        user.name = newname;
        user.email = email;
    }

    public string PostImage( IFormFile file)
    {
        if (file == null || file.Length == 0) throw new ArgumentException("No image uploaded");
        string[] allowedExtensions = { ".jpg", ".jpeg", ".png" };
        string fileExtension = Path.GetExtension(file.FileName).ToLower();

        if (!allowedExtensions.Contains(fileExtension))
            throw new ArgumentException("Only JPG, JPEG, and PNG files are allowed.");

        try
        {
            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            string filePath = Path.Combine(uploadFolder, uniqueName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return $"/uploads/{uniqueName}";
        }
        catch (Exception e)
        {
            throw new Exception("File upload failed");
        }


    }

    public void DeleteUser(long id)
    {
        User user = users.Find(user => user.Id == id);
        if(user == null) return;
        users.Remove(user);

    }



}