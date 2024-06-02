using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

namespace ACME.CargoApp.API.Registration.Domain.Model.Aggregates;

public class Trip
{
    public Trip()
    {
        Name = new Name();
        CargoData = new CargoData();
        TripData = new TripData();
        Driver = new Driver();
        Vehicle = new Vehicle();
    }
    
    
    public Trip(string name, string type, int weight, string loadLocation, DateTime loadDate, string unloadLocation, DateTime unloadDate, int driverId, int vehicleId, Driver driver, Vehicle vehicle)
    {
        Name = new Name(name);
        CargoData = new CargoData(type, weight);
        TripData = new TripData(loadLocation, loadDate, unloadLocation, unloadDate);
        DriverId = driverId;
        VehicleId = vehicleId;
        Driver = driver;
        Vehicle = vehicle;
    }
    public Trip(CreateTripCommand command, Driver driver, Vehicle vehicle)
    {
        Name = new Name(command.Name);
        CargoData = new CargoData(command.Type, command.Weight);
        TripData = new TripData(command.LoadLocation, command.LoadDate, command.UnloadLocation, command.UnloadDate);
        Driver = driver;
        Vehicle = vehicle;
    }
    
    public int Id { get; set; }
    public Name Name { get; internal set; }
    public CargoData CargoData { get; internal set; }
    public TripData TripData { get; internal set; }
    
    public Driver Driver { get; internal set; }
    public Vehicle Vehicle { get; internal set; }
    public int DriverId { get; internal set; }
    public int VehicleId { get; internal set; }
    
    public Expense Expense { get; internal set; }
    public Evidence Evidence { get; internal set; }
}