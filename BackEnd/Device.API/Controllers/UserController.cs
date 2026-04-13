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
    
    [HttpPost]
    public void AddNewUser(User user)
    {
        _service.AddNewUser(user);
    }
    
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var user = _service.VerifyUser(request.Email, request.Password);

        if (user == null)
            return Unauthorized("Invalid email or password.");

        user.Password = null; 
        return Ok(user);
    }
    
    [HttpGet("users")]
    public ActionResult<List<User>> GetUsers()
    {
        var users = _service.ListAllUsers();
        if (!users.Any())
            return NoContent();
        
        return users;
    }
}