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
        try
        {
            var createTripCommand = CreateTripCommandFromResourceAssembler.ToCommandFromResource(createTripResource);
            var trip = await tripCommandService.Handle(createTripCommand);
            if (trip is null) return BadRequest();
            var resource = TripResourceFromEntityAssembler.ToResourceFromEntity(trip);
            return CreatedAtAction(nameof(GetTripById), new { tripId = resource.Id }, resource);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the trip. " + e.Message });
        }
    }
    
    [HttpPut("{tripId}")]
    public async Task<IActionResult> UpdateTrip([FromBody] UpdateTripResource updateTripResource, [FromRoute] int tripId)
    {
        try
        {
            var updateTripCommand = UpdateTripCommandFromResourceAssembler.ToCommandFromResource(updateTripResource, tripId);
            var trip = await tripCommandService.Handle(updateTripCommand);
            if (trip is null) return BadRequest();
            var resource = TripResourceFromEntityAssembler.ToResourceFromEntity(trip);
            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while updating the trip. " + e.Message });
        }
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
    
    [HttpGet("{tripId}/alerts")]
    public async Task<IActionResult> GetAlertsByTripId([FromRoute] int tripId)
    {
        var alerts = await tripQueryService.Handle(new GetAlertsByTripIdQuery(tripId));
        if (alerts == null) return NotFound();
        var resources = alerts.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{tripId}/ongoingTrips")]
    public async Task<IActionResult> GetOngoingByTripId([FromRoute] int tripId)
    {
        var ongoingTrips = await tripQueryService.Handle(new GetOngGoingTripByIdQuery(tripId));
        if (ongoingTrips == null) return NotFound();
        var resources = ongoingTrips.Select(OngoingTripResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

    [HttpGet("{tripId}/evidences")]
    public async Task<IActionResult> GetEvidencesByTripId([FromRoute] int tripId)
    {
        var evidence = await tripQueryService.Handle(new GetEvidencesByTripIdQuery(tripId));
        if (evidence == null) return NotFound();
        var resource = EvidenceResourceFromEntityAssembler.ToResourceFromEntity(evidence);
        return Ok(resource);
    }
    
}