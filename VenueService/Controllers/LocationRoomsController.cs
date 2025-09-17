using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationRoomsController(ILocationRoomService locationRoomService) : ControllerBase
{
    private readonly ILocationRoomService _locationRoomService = locationRoomService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _locationRoomService.GetAllLocationRoomsAsync();
        return result.Success ? Ok(result.Result) : StatusCode(500, result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _locationRoomService.GetLocationRoomByRoomIdAsync(id);
        return result.Success ? Ok(result.Result) : NotFound(result.Error);
    }

    [HttpGet("/api/[controller]/{locationId}/rooms")]
    public async Task<IActionResult> GetAllByLocationId(string locationId)
    {
        var result = await _locationRoomService.GetLocationRoomsByLocationIdAsync(locationId);
        return result.Success
            ? Ok(result.Result)
            : NotFound(result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationRoomRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _locationRoomService.CreateLocationRoomAsync(request);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateLocationRoomRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _locationRoomService.UpdateLocationRoomAsync(id, request);
        return result.Success ? Ok(result) : NotFound(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _locationRoomService.DeleteLocationRoomAsync(id);
        return result.Success ? Ok(result) : NotFound(result.Error);
    }
}

