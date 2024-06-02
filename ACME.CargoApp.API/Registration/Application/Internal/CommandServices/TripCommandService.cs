using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class TripCommandService(ITripRepository tripRepository, IDriverRepository driverRepository, IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    : ITripCommandService
{
    public async Task<Trip?> Handle(CreateTripCommand command)
    {
        //Additional validation to check if the driver and vehicle exist
        var driver = await driverRepository.FindByIdAsync(command.DriverId);
        if (driver == null)
        {
            throw new ArgumentException("DriverId not found.");
        }
        
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null)
        {
            throw new ArgumentException("VehicleId not found.");
        }
        //Create the trip
        var trip = new Trip(command, driver, vehicle);
        try
        { 
            await tripRepository.AddAsync(trip);
            await unitOfWork.CompleteAsync();
            return trip;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the trip: {e.Message}");
            return null;
        }
        
        
        
    }
    
public async Task<Trip?> Handle(UpdateTripCommand command)
    {
        var driver = await driverRepository.FindByIdAsync(command.DriverId);
        if (driver == null)
        {
            throw new ArgumentException("DriverId not found.");
        }
        
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null)
        {
            throw new ArgumentException("VehicleId not found.");
        }
        
        var trip = await tripRepository.FindByIdAsync(command.TripId);
        if (trip == null)
        {
            return null;
        }
        //Update the trip information
        trip.Name = new Name(command.Name);
        trip.CargoData = new CargoData(command.Type, command.Weight);
        trip.TripData = new TripData(command.LoadLocation, command.LoadDate, command.UnloadLocation, command.UnloadDate);
        trip.DriverId = command.DriverId;
        trip.VehicleId = command.VehicleId;
        trip.Vehicle = vehicle;
        trip.Driver = driver;
        
        await unitOfWork.CompleteAsync();
        return trip;
    }
}