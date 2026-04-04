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
    
    [HttpGet]
    public ActionResult<List<Models.Device>> GetDevices()
    {
        return Ok(_service.ListAllDevices());
    }
}