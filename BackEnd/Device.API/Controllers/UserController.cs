using Device.API.Models;
using Microsoft.AspNetCore.HttpLogging;
using Device.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _service;

    public UserController(UserService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _service.GetUserById(id);

        if (user == null)
            return NotFound();
        return user;
    }

    [HttpGet("users")]
    public ActionResult<List<User>> GetUsers()
    {
        var users = _service.ListAllUsers();
        if (!users.Any())
            return NoContent();
        
        return users;
    }

    [HttpPost]
    public void AddNewUser(User user)
    {
        _service.AddNewUser(user);
    }

    [HttpDelete]
    public void DeleteUserById(int id)
    {
        _service.DeleteUserById(id);
    }

    [HttpPut("{id}")]
    public void UpdateUserById(int id, User user)
    {
        _service.UpdateUserById(id, user);
    }
}