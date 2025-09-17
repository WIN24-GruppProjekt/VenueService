using Application.DTOs;
using Application.Models;

namespace Application.Services
{
    public interface ILocationRoomService
    {
        Task<LocationRoomResult> CreateLocationRoomAsync(CreateLocationRoomRequest request);
        Task<LocationRoomResult> DeleteLocationRoomAsync(int roomId);
        Task<LocationRoomResult<IEnumerable<LocationRoom>>> GetAllLocationRoomsAsync();
        Task<LocationRoomResult<LocationRoom>> GetLocationRoomByIdAsync(int roomId);
        Task<LocationRoomResult> UpdateLocationRoomAsync(int roomId, CreateLocationRoomRequest request);
    }
}