namespace ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

public record CargoData(string Type, int Weight)
{
    public CargoData() : this(string.Empty, 0)
    {
    }
}