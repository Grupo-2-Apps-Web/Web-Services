using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class VehicleQueryService(IVehicleRepository vehicleRepository)
    : IVehicleQueryService
{
    public async Task<Vehicle?> Handle(GetVehicleByIdQuery query)
    {
        return await vehicleRepository.FindByIdAsync(query.VehicleId);
    }
    
    public async Task<IEnumerable<Vehicle>> Handle(GetAllVehiclesQuery query)
    {
        return await vehicleRepository.ListAsync();
    }
}