using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class UpdateVehicleCommandFromResourceAssembler
{
    public static UpdateVehicleCommand ToCommandFromResource(UpdateVehicleResource resource, int vehicleId)
    {
        return new UpdateVehicleCommand(vehicleId, resource.Model, resource.Plate, resource.TractorPlate, resource.MaxLoad, resource.Volume);
    }
    
}