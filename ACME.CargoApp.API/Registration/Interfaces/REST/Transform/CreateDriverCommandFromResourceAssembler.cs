using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class CreateDriverCommandFromResourceAssembler
{
    public static CreateDriverCommand ToCommandFromResource(CreateDriverResource resource)
    {
        return new CreateDriverCommand(resource.Name, resource.Dni, resource.License, resource.ContactNumber);
    }
}