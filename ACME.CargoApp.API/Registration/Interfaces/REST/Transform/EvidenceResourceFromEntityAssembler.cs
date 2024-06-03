using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public class EvidenceResourceFromEntityAssembler
{
    public static EvidenceResource ToResourceFromEntity(Evidence entity)
    {
        Console.WriteLine("Evidence link is " + entity.Link);
        return new EvidenceResource(entity.Id, entity.Link, entity.TripId);
    }
}