namespace ACME.CargoApp.API.User.Domain.Model.ValueObjects;

public record UserData(string Name, string Phone, string Ruc, string Address)
{
    public UserData() : this(string.Empty, string.Empty, string.Empty, string.Empty)
    {
    }
}