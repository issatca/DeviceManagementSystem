using Device.API.Services;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Device.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly DeviceService _service;

    public DeviceController(DeviceService service)
    {
        _service = service;
    }
    
    [HttpGet("devices")]
    public ActionResult<List<Models.Device>> GetDevices()
    {
        var devices = _service.ListAllDevices();
        if (!devices.Any())
            return NoContent();
        
        return Ok(devices);
    }

    [HttpGet("{id}")]
    public ActionResult<Models.Device> GetDeviceById(int id)
    {
        var device = _service.GetDeviceById(id);

        if (device == null)
            return NotFound();

        return Ok(device);
    }

    [HttpPost]
    public void AddNewDevice(Models.Device device)
    {
        if (device == null)
        {
            throw new ArgumentNullException(nameof(device), "Device data cannot be null.");
        }

        _service.AddNewDevice(device);
    }
    
    [HttpPut("{id}")]
    public void UpdateDeviceById(int id, Models.Device device)
    {
        _service.UpdateDeviceById(id, device);
    }

    [HttpDelete("{id}")]
    public void DeleteDeviceById(int id)
    {
        _service.DeleteDeviceById(id);
    }
    
    [HttpPost("{deviceId}/assign/{userId}")]
    public IActionResult Assign(int deviceId, int userId)
    {
        var success = _service.AssignDevice(deviceId, userId);
    
        if (!success)
            return BadRequest("Device is already assigned or does not exist.");

        return Ok("Device assigned successfully.");
    }

    [HttpPost("{deviceId}/unassign/{userId}")]
    public IActionResult Unassign(int deviceId, int userId)
    {
        var success = _service.UnassignDevice(deviceId, userId);
    
        if (!success)
            return BadRequest("You cannot unassign a device that is not yours.");

        return Ok("Device unassigned successfully.");
    }
}