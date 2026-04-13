namespace Device.API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Location { get; set; }
}