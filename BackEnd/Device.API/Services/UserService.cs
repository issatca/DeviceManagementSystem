using BCrypt.Net;
using Device.API.DbStorage;
using Device.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Services;

public class UserService
{
    private readonly DeviceManagementContext _context;

    public UserService(DeviceManagementContext context)
    {
        _context = context;
    }

    public void AddNewUser(User user)
    {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    
    public User? VerifyUser(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Mail == email);
        if (user == null) return null;

        bool isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
        
        return isValid ? user : null;
    }
    
    public List<User> ListAllUsers()
    {
        return _context.Users.ToList();
    }
}