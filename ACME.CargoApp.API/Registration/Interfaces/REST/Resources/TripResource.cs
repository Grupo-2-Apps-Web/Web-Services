using ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

public record TripResource(int Id, Name Name, CargoData CargoData, TripData TripData, int DriverId, int VehicleId);