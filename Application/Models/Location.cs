
namespace Application.Models;

public class Location
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }
    public ICollection<LocationRoom>? Rooms { get; set; }
}
