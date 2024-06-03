using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
using ACME.CargoApp.API.Registration.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.Registration.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class AlertsController(IAlertCommandService alertCommandService, IAlertQueryService alertQueryService)
    :ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAlert([FromBody] CreateAlertResource createAlertResource)
    {
        var createAlertCommand = CreateAlertCommandFromResourceAssembler.ToCommandFromResource(createAlertResource);
        var alert = await alertCommandService.Handle(createAlertCommand);
        if (alert is null) return BadRequest();
        var resource = AlertResourceFromEntityAssembler.ToResourceFromEntity(alert);
        return CreatedAtAction(nameof(GetAlertById), new { alertId = resource.Id }, resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAlerts()
    {
        var getAllAlertsQuery = new GetAllAlertsQuery();
        var alerts = await alertQueryService.Handle(getAllAlertsQuery);
        var resources = alerts.Select(AlertResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{alertId}")]
    public async Task<IActionResult> GetAlertById([FromRoute] int alertId)
    {
        var alert = await alertQueryService.Handle(new GetAlertByIdQuery(alertId));
        if (alert == null) return NotFound();
        var resource = AlertResourceFromEntityAssembler.ToResourceFromEntity(alert);
        return Ok(resource);
    }
}