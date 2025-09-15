
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Model;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class LocationRepository(DataContext context) : BaseRepository<LocationEntity>(context), ILocationRepository
{
    public override async Task<RepositoryResult<IEnumerable<LocationEntity>>> GetAllAsync(LocationEntity entity)
    {
        try
        {
            var entities = await _table.Include(x => x.Rooms).ToListAsync();
            return new RepositoryResult<IEnumerable<LocationEntity>>
            {
                Success = true,
                Result = entities
            };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<LocationEntity>>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }

    public override async Task<RepositoryResult<LocationEntity?>> GetAsync(Expression<Func<LocationEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.Rooms).FirstOrDefaultAsync(expression) ?? throw new Exception("Not found.");
            return new RepositoryResult<LocationEntity?> { Success = true, Result = entity };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<LocationEntity?>
            {
                Success = false,
                Error = ex.Message
            };
        }
    }
}
