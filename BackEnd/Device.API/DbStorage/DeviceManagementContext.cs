using Device.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Device.API.DbStorage;

public class DeviceManagementContext : DbContext
{
    public DbSet<Models.Device> Devices { get; set; }
    public DbSet<User> Users { get; set; }

    public DeviceManagementContext(DbContextOptions<DeviceManagementContext> options) : base(options) {}

    //enum - string relation
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.Device>(entity =>
        {
            entity.Property(e => e.Type).HasColumnName("type").HasConversion<string>();
        });
    }
}