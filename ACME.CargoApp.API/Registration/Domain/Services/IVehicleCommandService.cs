using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IVehicleCommandService
{
    Task<Vehicle?> Handle(CreateVehicleCommand createVehicleCommand);
    Task<Vehicle?> Handle(UpdateVehicleCommand updateVehicleCommand);
}