using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public class UpdateEvidenceCommandFromResourceAssembler
{
    public static UpdateEvidenceCommand ToCommandFromResource(UpdateEvidenceResource resource, int evidenceId)
    {
        return new UpdateEvidenceCommand(evidenceId, resource.Link, resource.TripId);
    }
}