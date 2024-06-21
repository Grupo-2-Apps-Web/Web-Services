using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface ITripQueryService
{
    Task<IEnumerable<Trip>> Handle(GetAllTripsQuery query);
    Task<Trip?> Handle(GetTripByIdQuery query);
    Task<Evidence?> Handle(GetEvidencesByTripIdQuery query);
    Task<IEnumerable<Alert>> Handle(GetAlertsByTripIdQuery query);
    Task<IEnumerable<OngoingTrip>> Handle(GetOngGoingTripByIdQuery query);
    Task<IEnumerable<Driver>> Handle(GetDriversByEntrepreneurIdQuery query);
}