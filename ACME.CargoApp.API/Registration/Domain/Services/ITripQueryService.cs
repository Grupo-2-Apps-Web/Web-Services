using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface ITripQueryService
{
    Task<IEnumerable<Trip>> Handle(GetAllTripsQuery query);
    Task<Trip?> Handle(GetTripByIdQuery query);
}