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

    public void AddNewDevice(Models.Device device)
    {
        _context.Devices.Add((device));
        _context.SaveChanges();
    }

    public void DeleteDeviceById(int id)
    {
        var device = _context.Devices.FirstOrDefault(d => d.Id == id);
        _context.Devices.Remove(device);
        _context.SaveChanges();
    }

    public void UpdateDeviceById(int id, Models.Device device)
    {
        var existingDevice = _context.Devices.FirstOrDefault(d => d.Id == id);
        
        existingDevice.Name = device.Name;
        existingDevice.Manufacturer = device.Manufacturer;
        existingDevice.Type = device.Type;
        existingDevice.OperatingSystem = device.OperatingSystem;
        existingDevice.OsVersion = device.OsVersion;
        existingDevice.Processor = device.Processor;
        existingDevice.RamAmount = device.RamAmount;
        existingDevice.Description = device.Description;
        existingDevice.UserID = device.UserID;

        _context.SaveChanges();
    }
}