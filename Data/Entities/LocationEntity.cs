using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities;

public class LocationEntity // Location implies "Gym Location"
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required(ErrorMessage = "The location must have a name")]
    public string Name { get; set; } = null!;
    
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;
    
    [Required(ErrorMessage = "Postal code is required")]
    public string PostalCode { get; set; } = null!;
    
    [Required(ErrorMessage = "Phone number is required")]
    [Phone]
    public string Telephone { get; set; } = null!;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Opening time is required")]
    public TimeOnly OpensAt { get; set; }
   
    [Required(ErrorMessage = "Closing time is required")]
    public TimeOnly ClosesAt { get; set; }

    // A Location can have multiple training rooms for group classes, we want to fetch the associated rooms when we fetch a location

    public ICollection<LocationRoomEntity> Rooms { get; set; } = [];

}
