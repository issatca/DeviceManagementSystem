using Device.API.DbStorage;

namespace Device.API.Services;

public class DeviceService
{
    private readonly DeviceManagementContext _context;

    public DeviceService(DeviceManagementContext context)
    {
        _context = context;
    }

    public Models.Device GetDeviceById(int id)
    {
        return _context.Devices.FirstOrDefault(d => d.Id == id);
    }

    public List<Models.Device> ListAllDevices()
    {
        return _context.Devices.ToList();
    }
}