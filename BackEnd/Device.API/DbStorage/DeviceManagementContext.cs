using Microsoft.EntityFrameworkCore;

namespace Device.API.DbStorage;

public class DeviceManagementContext : DbContext
{
    public DbSet<Models.Device> Devices { get; set; }

    public DeviceManagementContext(DbContextOptions<DeviceManagementContext> options) : base(options) {}
}