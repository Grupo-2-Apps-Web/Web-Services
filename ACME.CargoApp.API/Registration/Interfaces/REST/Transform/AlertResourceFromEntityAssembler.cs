using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class AlertResourceFromEntityAssembler
{
    public static AlertResource ToResourceFromEntity(Alert entity)
    {
        return new AlertResource(entity.Id, entity.Title, entity.Description, entity.Date, entity.TripId);
    }
}