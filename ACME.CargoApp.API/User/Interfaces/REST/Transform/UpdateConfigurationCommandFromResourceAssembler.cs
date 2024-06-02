using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class UpdateConfigurationCommandFromResourceAssembler
{
    public static UpdateConfigurationCommand ToCommandFromResource(UpdateConfigurationResource resource, int configurationId)
    {
        return new UpdateConfigurationCommand(configurationId, resource.Theme, resource.View, 
            resource.AllowDataCollection, resource.UpdateDataSharing);
    }
}