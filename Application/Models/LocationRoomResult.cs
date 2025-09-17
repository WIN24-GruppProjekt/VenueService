

namespace Application.Models;

public class LocationRoomResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }
}

public class LocationRoomResult<T> : LocationRoomResult
{
    public T? Result { get; set; }
}