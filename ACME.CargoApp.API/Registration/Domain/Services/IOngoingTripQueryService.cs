using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IOngoingTripQueryService
{
    Task<OngoingTrip?> Handle(GetOnGoingTripByIdQuery query);
    Task<IEnumerable<OngoingTrip>> Handle(GetAllOngoingTripsQuery query);
}