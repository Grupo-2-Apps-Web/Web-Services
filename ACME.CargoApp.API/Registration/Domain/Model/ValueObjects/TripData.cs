using System.Runtime.InteropServices.JavaScript;

namespace ACME.CargoApp.API.Registration.Domain.Model.ValueObjects;

public record TripData(string LoadLocation, DateTime LoadDate, string UnloadLocation, DateTime UnloadDate)
{
    public TripData() : this(string.Empty, new DateTime(), string.Empty, new DateTime())
    {
    }
}