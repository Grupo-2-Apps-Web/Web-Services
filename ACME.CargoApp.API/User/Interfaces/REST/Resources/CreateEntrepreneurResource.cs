namespace ACME.CargoApp.API.User.Interfaces.REST.Resources;

public record CreateEntrepreneurResource(string Name, string Phone, string Ruc, string Address, string Subscription, int UserId, string LogoImage);