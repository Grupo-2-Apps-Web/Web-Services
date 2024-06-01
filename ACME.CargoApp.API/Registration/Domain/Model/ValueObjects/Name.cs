namespace ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

public record Name(string TripName)
{
    public Name() : this(string.Empty)
    {
    }
}
