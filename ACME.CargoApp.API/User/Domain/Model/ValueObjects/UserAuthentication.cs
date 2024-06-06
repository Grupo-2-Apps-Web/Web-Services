namespace ACME.CargoApp.API.User.Domain.Model.ValueObjects;

public record UserAuthentication(string Email, string Password)
{
    public UserAuthentication() : this(string.Empty, string.Empty)
    {
    }
}