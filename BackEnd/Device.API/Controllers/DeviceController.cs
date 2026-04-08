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

    [HttpDelete]
    public void DeleteDeviceById(int id)
    {
        _service.DeleteDeviceById(id);
    }

    [HttpPut("{id}")]
    public void UpdateDeviceById(int id, Models.Device device)
    {
        _service.UpdateDeviceById(id, device);
    }
    
    [HttpGet("devices")]
    public ActionResult<List<Models.Device>> GetDevices()
    {
        var devices = _service.ListAllDevices();
        if (!devices.Any())
            return NoContent();
        
        return Ok(devices);
    }
}