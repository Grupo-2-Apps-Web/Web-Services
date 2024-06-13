using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class DriverResourceFromEntityAssembler
{
    public static DriverResource ToResourceFromEntity(Driver entity)
    {
        return new DriverResource(entity.Id, entity.Name, entity.Dni, entity.License, entity.ContactNumber);
    }
}