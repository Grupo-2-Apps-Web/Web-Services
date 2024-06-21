using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.QueryServices;

public class ConfigurationQueryService(IConfigurationRepository configurationRepository) : IConfigurationQueryService
{
    public async Task<IEnumerable<Configuration>> Handle(GetAllConfigurationsQuery query)
    {
        return await configurationRepository.ListAsync();
    }
    
    public async Task<Configuration?> Handle(GetConfigurationByIdQuery query)
    {
        return await configurationRepository.FindByIdAsync(query.ConfigurationId);
    }
    
    public async Task<Configuration?> Handle(GetConfigurationByUserIdQuery query)
    {
        return await configurationRepository.FindByUserIdAsync(query.UserId);
    }
}