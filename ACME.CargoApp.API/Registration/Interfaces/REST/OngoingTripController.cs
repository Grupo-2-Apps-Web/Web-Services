using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
using ACME.CargoApp.API.Registration.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.Registration.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class OngoingTripController(IOngoingTripCommandService ongoingTripCommandService, IOngoingTripQueryService ongoingTripQueryService)
    :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOngoingTrip([FromBody] CreateOngoingTripResource createOngoingTripResource)
    {
        var createOngoingTripCommand = CreateOngoingTripCommandFromResourceAssembler.ToCommandFromResource(createOngoingTripResource);
        var ongoingTrip = await ongoingTripCommandService.Handle(createOngoingTripCommand);
        if (ongoingTrip is null) return BadRequest();
        var resource = OngoingTripResourceFromEntityAssembler.ToResourceFromEntity(ongoingTrip);
        return CreatedAtAction(nameof(GetOngoingTripById), new { ongoingTripId = resource.Id }, resource);
    }
    
    [HttpPut("{ongoingTripId}")]
    public async Task<IActionResult> UpdateOngoingTrip([FromBody] UpdateOngoingTripResource updateOngoingTripResource, [FromRoute] int ongoingTripId)
    {
        var updateOngoingTripCommand = UpdateOngoingTripCommandFromResourceAssembler.ToCommandFromResource(updateOngoingTripResource, ongoingTripId);
        
        var ongoingTrip = await ongoingTripCommandService.Handle(updateOngoingTripCommand);
        if (ongoingTrip is null) return BadRequest();
        var resource = OngoingTripResourceFromEntityAssembler.ToResourceFromEntity(ongoingTrip);
        return Ok(resource);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAllOngoingTrips()
    {
        var getAllOngoingTripsQuery = new GetAllOngoingTripsQuery();
        var ongoingTrips = await ongoingTripQueryService.Handle(getAllOngoingTripsQuery);
        var resources = ongoingTrips.Select(OngoingTripResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{ongoingTripId}")]
    public async Task<IActionResult> GetOngoingTripById([FromRoute] int ongoingTripId)
    {
        var ongoingTrip = await ongoingTripQueryService.Handle(new GetOnGoingTripByIdQuery(ongoingTripId));
        if (ongoingTrip == null) return NotFound();
        var resource = OngoingTripResourceFromEntityAssembler.ToResourceFromEntity(ongoingTrip);
        return Ok(resource);
    }
    
}