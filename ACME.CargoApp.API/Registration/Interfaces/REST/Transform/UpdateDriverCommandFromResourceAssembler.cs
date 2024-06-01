using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class UpdateDriverCommandFromResourceAssembler
{ 
    public static UpdateDriverCommand ToCommandFromResource(UpdateDriverResource resource, int driverId)
    {
        return new UpdateDriverCommand(driverId, resource.Name, resource.Dni, resource.License, resource.ContactNumber);
    }
}