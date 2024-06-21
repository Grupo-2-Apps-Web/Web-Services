namespace ACME.CargoApp.API.User.Domain.Model.Commands;

public record CreateClientCommand(string Name, string Phone, string Ruc, string Address, string Subscription, int UserId);