
using Persistence.Contexts;
using Persistence.Entities;

namespace Persistence.Repositories;

public class LocationRoomRepository(DataContext context) : BaseRepository<LocationRoomEntity>(context), ILocationRoomRepository
{
}
