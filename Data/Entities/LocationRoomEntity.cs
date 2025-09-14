
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities;

public class LocationRoomEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Room name is required")]
    public string RoomName { get; set; } = null!;
    
    [Required(ErrorMessage = "The room capacity must be specified")]
    [Range(1, 500)]
    public int RoomCapacity { get; set; } = 0; // Maximum number of people allowed in the room

    //Foreign keys

    [ForeignKey(nameof(Location))]
    public string LocationId { get; set; } = null!;
    public LocationEntity Location { get; set; } = null!;

}
