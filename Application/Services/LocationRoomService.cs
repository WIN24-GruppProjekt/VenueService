using Application.DTOs;
using Application.Models;
using Persistence.Entities;
using Persistence.Repositories;

namespace Application.Services;

public class LocationRoomService(ILocationRoomRepository locationRoomRepository, ILocationRepository locationRepository) : ILocationRoomService
{
    private readonly ILocationRoomRepository _locationRoomRepository = locationRoomRepository;
    private readonly ILocationRepository _locationRepository = locationRepository;

    public async Task<LocationRoomResult> CreateLocationRoomAsync(CreateLocationRoomRequest request)
    {
        try
        {
            var locationRoomEntity = new LocationRoomEntity
            {
                RoomName = request.RoomName,
                RoomCapacity = request.RoomCapacity,
                LocationId = request.LocationId
            };

            var result = await _locationRoomRepository.AddAsync(locationRoomEntity);

            return result.Success
                ? new LocationRoomResult { Success = true }
                : new LocationRoomResult { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new LocationRoomResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<LocationRoomResult<IEnumerable<LocationRoom>>> GetAllLocationRoomsAsync()
    {
        var result = await _locationRoomRepository.GetAllAsync();
        var locationRooms = result.Result?.Select(x => new LocationRoom
        {
            Id = x.Id,
            RoomName = x.RoomName,
            RoomCapacity = x.RoomCapacity,
            LocationId = x.LocationId
        });
        return result.Success
            ? new LocationRoomResult<IEnumerable<LocationRoom>> { Success = true, Result = locationRooms }
            : new LocationRoomResult<IEnumerable<LocationRoom>> { Success = false, Error = result.Error };
    }

    public async Task<LocationRoomResult<LocationRoom>> GetLocationRoomByRoomIdAsync(int roomId)
    {
        var result = await _locationRoomRepository.GetAsync(x => x.Id == roomId);
        if (result.Result == null)
        {
            return new LocationRoomResult<LocationRoom> { Success = false, Error = "Room not found" };
        }
        var locationRoom = new LocationRoom
        {
            Id = result.Result.Id,
            RoomName = result.Result.RoomName,
            RoomCapacity = result.Result.RoomCapacity,
            LocationId = result.Result.LocationId
        };
        return result.Success
            ? new LocationRoomResult<LocationRoom> { Success = true, Result = locationRoom }
            : new LocationRoomResult<LocationRoom> { Success = false, Error = result.Error };
    }

    public async Task<LocationRoomResult<IEnumerable<LocationRoom>>> GetLocationRoomsByLocationIdAsync(string locationId)
    {
        var result = await _locationRepository.GetAsync(x => x.Id == locationId);

        if (!result.Success || result.Result == null)
        {
            return new LocationRoomResult<IEnumerable<LocationRoom>>
            {
                Success = false,
                Error = result.Error ?? "Location not found"
            };
        }
        var locationRooms = result.Result.Rooms?
            .Select(x => new LocationRoom
            {
                Id = x.Id,
                RoomName = x.RoomName,
                RoomCapacity = x.RoomCapacity,
                LocationId = x.LocationId
            })
            .ToList() ?? new List<LocationRoom>();

        return new LocationRoomResult<IEnumerable<LocationRoom>>
        {
            Success = true,
            Result = locationRooms
        };
    }


    public async Task<LocationRoomResult> UpdateLocationRoomAsync(int roomId, CreateLocationRoomRequest request)
    {
        try
        {
            var existingRoomResult = await _locationRoomRepository.GetAsync(x => x.Id == roomId);
            if (!existingRoomResult.Success || existingRoomResult.Result == null)
            {
                return new LocationRoomResult { Success = false, Error = "Room not found" };
            }
            var existingRoom = existingRoomResult.Result;
            existingRoom.RoomName = request.RoomName;
            existingRoom.RoomCapacity = request.RoomCapacity;
            var updateResult = await _locationRoomRepository.UpdateAsync(existingRoom);
            return updateResult.Success
                ? new LocationRoomResult { Success = true }
                : new LocationRoomResult { Success = false, Error = updateResult.Error };
        }
        catch (Exception ex)
        {
            return new LocationRoomResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<LocationRoomResult> DeleteLocationRoomAsync(int roomId)
    {
        try
        {
            var existingRoomResult = await _locationRoomRepository.GetAsync(x => x.Id == roomId);

            if (!existingRoomResult.Success || existingRoomResult.Result == null)
            {
                return new LocationRoomResult { Success = false, Error = "Room not found" };
            }

            var existingRoom = existingRoomResult.Result;
            var deleteResult = await _locationRoomRepository.DeleteAsync(existingRoom);
            return deleteResult.Success
                ? new LocationRoomResult { Success = true }
                : new LocationRoomResult { Success = false, Error = deleteResult.Error };
        }
        catch (Exception ex)
        {
            return new LocationRoomResult { Success = false, Error = ex.Message };
        }
    }

}
