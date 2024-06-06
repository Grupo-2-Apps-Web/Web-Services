using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class VehicleCommandService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : IVehicleCommandService
{
    public async Task<Vehicle?> Handle(CreateVehicleCommand command)
    {
        var vehicle = new Vehicle(command.Model, command.Plate, command.TractorPlate, command.MaxLoad, command.Volume);
        await vehicleRepository.AddAsync(vehicle);
        await unitOfWork.CompleteAsync();
        return vehicle;
    }
    
    public async Task<Vehicle?> Handle(UpdateVehicleCommand command)
    {
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null)
        {
            return null;
        }
        //Update the vehicle information
        vehicle.Model = command.Model;
        vehicle.Plate = command.Plate;
        vehicle.TractorPlate = command.TractorPlate;
        vehicle.MaxLoad = command.MaxLoad;
        vehicle.Volume = command.Volume;
        
        await unitOfWork.CompleteAsync();
        return vehicle;
    }
}