using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class UpdateOngoingTripCommandFromResourceAssembler
{
    public static UpdateOngoingTripCommand ToCommandFromResource(UpdateOngoingTripResource resource, int ongoingTripId)
    {
        return new UpdateOngoingTripCommand(ongoingTripId, resource.Latitude, resource.Longitude, resource.Speed, resource.Distance, resource.TripId);
    }
}