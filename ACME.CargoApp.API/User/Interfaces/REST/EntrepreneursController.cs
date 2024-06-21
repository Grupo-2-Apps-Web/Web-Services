using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Services;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;
using ACME.CargoApp.API.User.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.User.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class EntrepreneursController (IEntrepreneurQueryService entrepreneurQueryService, IEntrepreneurCommandService entrepreneurCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEntrepreneur([FromBody] CreateEntrepreneurResource createEntrepreneurResource)
    {
        try
        {
            var createEntrepreneurCommand = CreateEntrepreneurCommandFromResourceAssembler.ToCommandFromResource(createEntrepreneurResource);
            var entrepreneur = await entrepreneurCommandService.Handle(createEntrepreneurCommand);
            if (entrepreneur is null) return BadRequest();
            var resource = EntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
            return CreatedAtAction(nameof(GetEntrepreneurById), new { entrepreneurId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the entrepreneur. " + e.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEntrepreneurs()
    {
        var getAllEntrepreneursQuery = new GetAllEntrepreneursQuery();
        var entrepreneurs = await entrepreneurQueryService.Handle(getAllEntrepreneursQuery);
        var resources = entrepreneurs.Select(EntrepreneurResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{entrepreneurId}")]
    public async Task<IActionResult> GetEntrepreneurById([FromRoute] int entrepreneurId)
    {
        var entrepreneur = await entrepreneurQueryService.Handle(new GetEntrepreneurByIdQuery(entrepreneurId));
        if (entrepreneur == null) return NotFound();
        var resource = EntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
        return Ok(resource);
    }
    
    [HttpPut("{entrepreneurId}")]
    public async Task<IActionResult> UpdateEntrepreneur([FromBody] UpdateEntrepreneurResource updateEntrepreneurResource, [FromRoute] int entrepreneurId)
    {
        try
        {
            var updateEntrepreneurCommand = UpdateEntrepreneurCommandFromResourceAssembler.ToCommandFromResource(updateEntrepreneurResource, entrepreneurId);
            var entrepreneur = await entrepreneurCommandService.Handle(updateEntrepreneurCommand);
            if (entrepreneur is null) return BadRequest();
            var resource = EntrepreneurResourceFromEntityAssembler.ToResourceFromEntity(entrepreneur);
            return Ok(resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while updating the entrepreneur. " + e.Message });
        }
    }

    [HttpGet("{entrepreneurId}/drivers")]
    public async Task<IActionResult> GetDrivers([FromServices] ITripQueryService tripQueryService, int entrepreneurId)
    {
        var drivers = await tripQueryService.Handle(new GetDriversByEntrepreneurIdQuery(entrepreneurId));
        var driverResources = drivers.Select(d => new 
        {
            d.Id,
            d.Name,
            d.Dni,
            d.License,
            d.ContactNumber
        });
        return Ok(driverResources);
    }
}
