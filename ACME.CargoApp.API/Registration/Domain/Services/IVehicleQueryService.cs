using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IVehicleQueryService
{
    Task<Vehicle?> Handle(GetVehicleByIdQuery query);
    Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query);
}