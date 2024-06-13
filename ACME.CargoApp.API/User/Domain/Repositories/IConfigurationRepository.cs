using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Entities;
namespace ACME.CargoApp.API.User.Domain.Repositories;

public interface IConfigurationRepository : IBaseRepository<Configuration>
{
    Task<Configuration?> FindByUserIdAsync(int userId);
    
}