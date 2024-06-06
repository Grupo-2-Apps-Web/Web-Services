namespace ACME.CargoApp.API.User.Interfaces.REST.Resources;

public record CreateUserResource(string Name, string Phone, string Ruc, string Address, string Email, string Password, string Subscription);