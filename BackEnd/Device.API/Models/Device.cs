using System.ComponentModel.DataAnnotations.Schema;

namespace Device.API.Models;

public class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public DeviceType Type { get; set; }
    //variable - column name relation
    [Column("operating_system")]
    public string OperatingSystem { get; set; }
    [Column("os_version")]
    public string OsVersion { get; set; }
    public string Processor { get; set; }
    [Column("ram_amount")]
    public int RamAmount { get; set; }
    public string Description { get; set; }
    public int? UserID { get; set; }
}