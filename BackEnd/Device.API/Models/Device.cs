namespace Device.API.Models;

public class Device
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public DeviceType Type { get; set; }
    public string OperatingSystem { get; set; }
    public string OsVersion { get; set; }
    public string Processor { get; set; }
    public int RamAmount { get; set; }
    public string Description { get; set; }
}