

using Application.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs;

public class CreateLocationRequest
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [Required]
    public string Address { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;

    [Phone]
    public string Telephone { get; set; } = null!;

    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public TimeOnly OpensAt { get; set; }

    [Required]
    public TimeOnly ClosesAt { get; set; }

    public ICollection<LocationRoom>? Rooms { get; set; }
}
