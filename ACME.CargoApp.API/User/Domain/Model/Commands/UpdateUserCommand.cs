namespace ACME.CargoApp.API.User.Domain.Model.Commands;

public record UpdateUserCommand(int UserId, string Name, string Phone, string Ruc, string Address, string Email, string Password, string Subscription);