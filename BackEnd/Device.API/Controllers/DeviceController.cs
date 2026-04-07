using Device.API.Services;
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
    
    [HttpGet("devices")]
    public ActionResult<List<Models.Device>> GetDevices()
    {
        var devices = _service.ListAllDevices();
        if (!devices.Any())
            return NoContent();
        
        return Ok(devices);
    }
}