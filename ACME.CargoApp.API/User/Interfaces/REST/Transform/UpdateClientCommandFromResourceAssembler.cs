using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class UpdateClientCommandFromResourceAssembler
{
    public static UpdateClientCommand ToCommandFromResource(UpdateClientResource resource, int clientId)
    {
        return new UpdateClientCommand(clientId, resource.Name, resource.Phone, resource.Ruc, 
            resource.Address, resource.Subscription, resource.UserId);
    }
    
}