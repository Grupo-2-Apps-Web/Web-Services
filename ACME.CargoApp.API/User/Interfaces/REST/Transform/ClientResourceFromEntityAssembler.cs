using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class ClientResourceFromEntityAssembler
{
    public static ClientResource ToResourceFromEntity(Client entity)
    {
        return new ClientResource(entity.Id, entity.UserId);
    }
}