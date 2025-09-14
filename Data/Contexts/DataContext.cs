
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<LocationRoomEntity> LocationRooms { get; set; } 

}
