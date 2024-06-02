using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class CreateConfigurationCommandFromResourceAssembler
{
    public static CreateConfigurationCommand ToCommandFromResource(CreateConfigurationResource resource)
    {
        return new CreateConfigurationCommand(resource.UserId, resource.Theme, resource.View, resource.AllowDataCollection, resource.UpdateDataSharing);
    }
}