namespace ACME.CargoApp.API.Registration.Domain.Model.Commands;

public record CreateEvidenceCommand(string Link, int TripId);