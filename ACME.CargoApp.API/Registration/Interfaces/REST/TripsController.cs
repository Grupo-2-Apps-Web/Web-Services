using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
using ACME.CargoApp.API.Registration.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.Registration.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class TripsController(ITripQueryService tripQueryService, ITripCommandService tripCommandService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTrip([FromBody] CreateTripResource createTripResource)
    {
        var createTripCommand = CreateTripCommandFromResourceAssembler.ToCommandFromResource(createTripResource);
        var trip = await tripCommandService.Handle(createTripCommand);
        if (trip is null) return BadRequest();
        var resource = TripResourceFromEntityAssembler.ToResourceFromEntity(trip);
        return CreatedAtAction(nameof(GetTripById), new { tripId = resource.Id }, resource);
    }
    
    [HttpPut("{tripId}")]
    public async Task<IActionResult> UpdateTrip([FromBody] UpdateTripResource updateTripResource, [FromRoute] int tripId)
    {
        var updateTripCommand = UpdateTripCommandFromResourceAssembler.ToCommandFromResource(updateTripResource, tripId);
        
        var trip = await tripCommandService.Handle(updateTripCommand);
        if (trip is null) return BadRequest();
        var resource = TripResourceFromEntityAssembler.ToResourceFromEntity(trip);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTrips()
    {
        var getAllTripsQuery = new GetAllTripsQuery();
        var trips = await tripQueryService.Handle(getAllTripsQuery);
        var resources = trips.Select(TripResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{tripId}")]
    public async Task<IActionResult> GetTripById([FromRoute] int tripId)
    {
        var trip = await tripQueryService.Handle(new GetTripByIdQuery(tripId));
        if (trip == null) return NotFound();
        var resource = TripResourceFromEntityAssembler.ToResourceFromEntity(trip);
        return Ok(resource);
    }
    
}