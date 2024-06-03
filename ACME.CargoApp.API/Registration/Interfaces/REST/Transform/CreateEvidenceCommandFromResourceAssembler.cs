using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class CreateEvidenceCommandFromResourceAssembler
{
    public static CreateEvidenceCommand ToCommandFromResource(CreateEvidenceResource resource)
    {
        return new CreateEvidenceCommand(resource.Link, resource.TripId);
    }
}