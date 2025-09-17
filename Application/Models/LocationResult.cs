

namespace Application.Models;

public class LocationResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class LocationResult<T> : LocationResult
{
    public T? Data { get; set; }
}