
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){
    
    }
    
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<LocationRoomEntity> LocationRooms { get; set; } 

}
