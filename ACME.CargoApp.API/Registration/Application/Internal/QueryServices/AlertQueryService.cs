using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class AlertQueryService(IAlertRepository alertRepository)
    : IAlertQueryService
{
    public async Task<Alert?> Handle(GetAlertByIdQuery query)
    {
        return await alertRepository.FindByIdAsync(query.AlertId);
    }
    
    public async Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query)
    {
        return await alertRepository.ListAsync();
    }
}
