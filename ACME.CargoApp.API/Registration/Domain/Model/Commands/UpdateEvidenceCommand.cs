namespace ACME.CargoApp.API.Registration.Domain.Model.Commands;

public record UpdateEvidenceCommand(int EvidenceId, string Link, int TripId);