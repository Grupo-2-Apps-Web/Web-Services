namespace ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

public record AlertResource(int Id, string Title, string Description, DateTime Date, int TripId);