using Device.API.DbStorage;

namespace Device.API.Services;

public class DeviceService
{
    private readonly DeviceManagementContext _context;

    public DeviceService(DeviceManagementContext context)
    {
        _context = context;
    }

    public List<Models.Device> ListAllDevices()
    {
        return new List<Models.Device>();
    }
}