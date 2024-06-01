using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class DriverQueryService(IDriverRepository driverRepository)
    : IDriverQueryService
{
    public async Task<Driver?> Handle(GetDriverByIdQuery query)
    {
        return await driverRepository.FindByIdAsync(query.DriverId);
    }
    
    public async Task<IEnumerable<Driver>> Handle(GetAllDriversQuery query)
    {
        return await driverRepository.ListAsync();
    }
}

