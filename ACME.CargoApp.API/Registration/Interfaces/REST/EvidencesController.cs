using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
using ACME.CargoApp.API.Registration.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;


namespace ACME.CargoApp.API.Registration.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
public class EvidencesController (IEvidenceCommandService evidenceCommandService, IEvidenceQueryService evidenceQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateEvidence([FromBody] CreateEvidenceResource createEvidenceResource)
    {
        var createEvidenceCommand = CreateEvidenceCommandFromResourceAssembler.ToCommandFromResource(createEvidenceResource);
        var evidence = await evidenceCommandService.Handle(createEvidenceCommand);
        if (evidence is null) return BadRequest();
        var resource = EvidenceResourceFromEntityAssembler.ToResourceFromEntity(evidence);
        return CreatedAtAction(nameof(GetEvidenceById), new { evidenceId = resource.Id }, resource);
    }
    
    [HttpPut("{evidenceId}")]
    public async Task<IActionResult> UpdateEvidence([FromBody] UpdateEvidenceResource updateEvidenceResource, [FromRoute] int evidenceId)
    {
        var updateEvidenceCommand = UpdateEvidenceCommandFromResourceAssembler.ToCommandFromResource(updateEvidenceResource, evidenceId);
        
        var evidence = await evidenceCommandService.Handle(updateEvidenceCommand);
        if (evidence is null) return BadRequest();
        var resource = EvidenceResourceFromEntityAssembler.ToResourceFromEntity(evidence);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEvidences()
    {
        var getAllEvidencesQuery = new GetAllEvidencesQuery();
        var evidences = await evidenceQueryService.Handle(getAllEvidencesQuery);
        var resources = evidences.Select(EvidenceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{evidenceId}")]
    public async Task<IActionResult> GetEvidenceById([FromRoute] int evidenceId)
    {
        var evidence = await evidenceQueryService.Handle(new GetEvidenceByIdQuery(evidenceId));
        if (evidence == null) return NotFound();
        var resource = EvidenceResourceFromEntityAssembler.ToResourceFromEntity(evidence);
        return Ok(resource);
    }
}