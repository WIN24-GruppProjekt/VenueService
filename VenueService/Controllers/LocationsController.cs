using Application.DTOs;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationsController(ILocationService locationService) : ControllerBase
{
    private readonly ILocationService _locationService = locationService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _locationService.GetAllLocationsAsync();
        if (result.Success)
        {
            return Ok(result.Result);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var currentLocation = await _locationService.GetLocationByIdAsync(id);
        return currentLocation != null && currentLocation.Success
            ? Ok(currentLocation.Result)
            : NotFound("Location not found");
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateLocationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _locationService.CreateLocationAsync(request);
        return result.Success ? Ok(result) : StatusCode(500, result!.Error);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, CreateLocationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _locationService.UpdateLocationAsync(id, request);
        return result.Success ? Ok(result) : NotFound(result!.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await _locationService.DeleteLocationAsync(id);
        return result.Success ? Ok(result) : NotFound(result!.Error);
    }


}
