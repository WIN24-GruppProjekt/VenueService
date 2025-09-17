
using Application.DTOs;
using Application.Models;
using Persistence.Entities;
using Persistence.Repositories;
using System.Data;

namespace Application.Services;

public class LocationService(ILocationRepository locationRepository) : ILocationService
{
    private readonly ILocationRepository _locationRepository = locationRepository;

    public async Task<LocationResult> CreateLocationAsync(CreateLocationRequest request)
    {
        try
        {
            var LocationEntity = new LocationEntity
            {
                Name = request.Name,
                Address = request.Address,
                PostalCode = request.PostalCode,
                Telephone = request.Telephone,
                Email = request.Email,
                OpensAt = request.OpensAt,
                ClosesAt = request.ClosesAt
            };

            var result = await _locationRepository.AddAsync(LocationEntity);
            return result.Success
                ? new LocationResult { Success = true }
                : new LocationResult { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new LocationResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<LocationResult<IEnumerable<Location>>> GetAllLocationsAsync()
    {
        var result = await _locationRepository.GetAllAsync();
        var locations = result.Result?.Select(x => new Location
        {
            Id = x.Id,
            Name = x.Name,
            Address = x.Address,
            PostalCode = x.PostalCode,
            Telephone = x.Telephone,
            Email = x.Email,
            OpensAt = x.OpensAt,
            ClosesAt = x.ClosesAt,
            Rooms = x.Rooms.Select(r => new LocationRoom
            {
                Id = r.Id,
                RoomName = r.RoomName,
                RoomCapacity = r.RoomCapacity,
                LocationId = r.LocationId
            }).ToList()
        });

        return new LocationResult<IEnumerable<Location>>
        {
            Success = result.Success,
            Result = locations
        };
    }

    public async Task<LocationResult<Location?>> GetLocationByIdAsync(string LocationId)
    {
        var result = await _locationRepository.GetAsync(x => x.Id == LocationId);
        if (result.Success && result.Result != null)
        {
            var currentLocation = new Location
            {
                Id = result.Result.Id,
                Name = result.Result.Name,
                Address = result.Result.Address,
                PostalCode = result.Result.PostalCode,
                Telephone = result.Result.Telephone,
                Email = result.Result.Email,
                OpensAt = result.Result.OpensAt,
                ClosesAt = result.Result.ClosesAt,
                Rooms = result.Result.Rooms.Select(r => new LocationRoom
                {
                    Id = r.Id,
                    RoomName = r.RoomName,
                    RoomCapacity = r.RoomCapacity,
                    LocationId = r.LocationId
                }).ToList()
            };

            return new LocationResult<Location?> { Success = true, Result = currentLocation };
        }

        return new LocationResult<Location?> { Success = false, Error = result.Error };
    }

    public async Task<LocationResult> UpdateLocationAsync(string LocationId, CreateLocationRequest request)
    {
        try
        {
            var existingLocationResult = await _locationRepository.GetAsync(x => x.Id == LocationId);
            if (!existingLocationResult.Success || existingLocationResult.Result == null)
            {
                return new LocationResult { Success = false, Error = "Location not found" };
            }
            var existingLocation = existingLocationResult.Result;

            existingLocation.Name = request.Name;
            existingLocation.Address = request.Address;
            existingLocation.PostalCode = request.PostalCode;
            existingLocation.Telephone = request.Telephone;
            existingLocation.Email = request.Email;
            existingLocation.OpensAt = request.OpensAt;
            existingLocation.ClosesAt = request.ClosesAt;

            var updateResult = await _locationRepository.UpdateAsync(existingLocation);
            return updateResult.Success
                ? new LocationResult { Success = true }
                : new LocationResult { Success = false, Error = updateResult.Error };
        }
        catch (Exception ex)
        {
            return new LocationResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<LocationResult> DeleteLocationAsync(string LocationId)
    {
        try
        {
            var existingLocationResult = await _locationRepository.GetAsync(x => x.Id == LocationId);

            if (!existingLocationResult.Success || existingLocationResult.Result == null)
            {
                return new LocationResult { Success = false, Error = "Location not found" };
            }

            var existingLocation = existingLocationResult.Result;
            var deleteResult = await _locationRepository.DeleteAsync(existingLocation);
            return deleteResult.Success
                ? new LocationResult { Success = true }
                : new LocationResult { Success = false, Error = deleteResult.Error };
        }
        catch (Exception ex)
        {
            return new LocationResult { Success = false, Error = ex.Message };
        }
    }
}
