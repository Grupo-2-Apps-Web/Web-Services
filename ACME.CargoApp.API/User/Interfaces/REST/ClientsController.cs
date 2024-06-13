using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Services;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;
using ACME.CargoApp.API.User.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ACME.CargoApp.API.User.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
public class ClientsController(IClientQueryService clientQueryService, IClientCommandService clientCommandService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientResource createClientResource)
    {
        try
        {
            var createClientCommand = CreateClientCommandFromResourceAssembler.ToCommandFromResource(createClientResource);
            var client = await clientCommandService.Handle(createClientCommand);
            if (client is null) return BadRequest();
            var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(client);
            return CreatedAtAction(nameof(GetClientById), new { clientId = resource.Id }, resource);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new { message = "An error occurred while creating the client. " + e.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
        var getAllClientsQuery = new GetAllClientsQuery();
        var clients = await clientQueryService.Handle(getAllClientsQuery);
        var resources = clients.Select(ClientResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{clientId}")]
    public async Task<IActionResult> GetClientById([FromRoute] int clientId)
    {
        var client = await clientQueryService.Handle(new GetClientByIdQuery(clientId));
        if (client == null) return NotFound();
        var resource = ClientResourceFromEntityAssembler.ToResourceFromEntity(client);
        return Ok(resource);
    }
}