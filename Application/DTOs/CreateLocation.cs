

namespace Application.DTOs;

public class CreateLocation
{
    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public TimeOnly OpensAt { get; set; }

    public TimeOnly ClosesAt { get; set; }
}
