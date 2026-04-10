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
    
    public ActionResult<User> GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public List<User> ListAllUsers()
    {
        return _context.Users.ToList();
    }
    
    public void AddNewUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void DeleteUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        _context.Users.Remove(user);
        
        _context.SaveChanges();
    }

    public void UpdateUserById(int id, User user)
    {
        var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);

        existingUser.Name = user.Name;
        existingUser.Role = user.Role;
        existingUser.Location = user.Location;

        _context.SaveChanges();
    }
}