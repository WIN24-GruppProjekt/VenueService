
namespace Application.Models;

public class LocationRoom
{
    public int Id { get; set; } 
    public string RoomName { get; set; } = null!;
    public int RoomCapacity { get; set; }
    public string LocationId { get; set; } = null!;
}
