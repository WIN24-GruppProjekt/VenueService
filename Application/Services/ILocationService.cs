using Application.DTOs;
using Application.Models;

namespace Application.Services
{
    public interface ILocationService
    {
        Task<LocationResult> CreateLocationAsync(CreateLocationRequest request);
        Task<LocationResult> DeleteLocationAsync(string LocationId);
        Task<LocationResult<IEnumerable<Location>>> GetAllLocationsAsync();
        Task<LocationResult<Location?>> GetLocationByIdAsync(string LocationId);
        Task<LocationResult> UpdateLocationAsync(string LocationId, CreateLocationRequest request);
    }
}