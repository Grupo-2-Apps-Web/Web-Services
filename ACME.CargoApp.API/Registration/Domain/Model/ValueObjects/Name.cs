namespace ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

public record Name(string PersonName)
{
    public Name() : this(string.Empty)
    {
    }
}
