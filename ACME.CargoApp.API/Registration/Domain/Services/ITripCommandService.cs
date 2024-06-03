using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Commands;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface ITripCommandService
{
    Task<Trip?> Handle(CreateTripCommand createTripCommand);
    Task<Trip?> Handle(UpdateTripCommand updateTripCommand);
}