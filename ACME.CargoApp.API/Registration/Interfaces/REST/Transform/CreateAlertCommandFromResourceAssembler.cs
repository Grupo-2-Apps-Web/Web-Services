using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class CreateAlertCommandFromResourceAssembler
{
    public static CreateAlertCommand ToCommandFromResource(CreateAlertResource resource)
    {
        return new CreateAlertCommand(resource.Title, resource.Description, resource.Date, resource.TripId);
    }
}