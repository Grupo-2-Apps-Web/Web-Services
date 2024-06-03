using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;


public static class CreateOngoingTripCommandFromResourceAssembler
{
    public static CreateOngoingTripCommand ToCommandFromResource(CreateOngoingTripResource resource)
    {
        return new CreateOngoingTripCommand(resource.Latitude, resource.Longitude, resource.Speed, resource.Distance, resource.TripId);
    }
}