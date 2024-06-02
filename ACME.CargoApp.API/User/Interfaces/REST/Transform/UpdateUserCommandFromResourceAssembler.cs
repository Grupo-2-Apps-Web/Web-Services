using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class UpdateUserCommandFromResourceAssembler
{
    public static UpdateUserCommand ToCommandFromResource(UpdateUserResource resource, int userId)
    {
        return new UpdateUserCommand(userId, resource.Name, resource.Phone, resource.Ruc, resource.Address,
            resource.Email, resource.Password, resource.Subscription);
    }
}