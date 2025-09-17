
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateLocationRoomRequest
{
    [Required]
    public string RoomName { get; set; } = null!;

    [Range(1, 500, ErrorMessage = "Capacity must be between 1 and 500")]
    public int RoomCapacity { get; set; }

    [Required]
    public string LocationId { get; set; } = null!;
}
