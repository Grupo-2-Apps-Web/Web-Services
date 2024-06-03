namespace ACME.CargoApp.API.Registration.Domain.Model.Commands;

public record UpdateExpenseCommand(int ExpenseId, int FuelAmount, string FuelDescription, int ViaticsAmount, string ViaticsDescription, int TollsAmount, string TollsDescription, int TripId);