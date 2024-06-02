using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class CreateClientCommandFromResourceAssembler
{
    public static CreateClientCommand ToCommandFromResource(CreateClientResource resource)
    {
        return new CreateClientCommand(resource.UserId);
    }
    
}