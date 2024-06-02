using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class ConfigurationResourceFromEntityAssembler
{
    public static ConfigurationResource ToResourceFromEntity(Configuration entity)
    {
        return new ConfigurationResource(entity.Id, entity.UserId, entity.Theme, entity.View, entity.AllowDataCollection,
            entity.UpdateDataSharing);
    }
}