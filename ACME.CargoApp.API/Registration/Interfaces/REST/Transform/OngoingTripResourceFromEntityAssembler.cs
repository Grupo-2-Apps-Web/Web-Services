using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;
namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class OngoingTripResourceFromEntityAssembler
{
    public static OngoingTripResource ToResourceFromEntity(OngoingTrip entity)
    {
        Console.WriteLine("OngoingTrip's distance is " + entity.Distance);
        return new OngoingTripResource(entity.Id, entity.Latitude, entity.Longitude, entity.Speed, entity.Distance, entity.TripId);
    }
}