namespace ACME.CargoApp.API.User.Domain.Model.Commands;

public record CreateUserCommand(string Name, string Phone, string Ruc, string Address, string Email, string Password, string Subscription);