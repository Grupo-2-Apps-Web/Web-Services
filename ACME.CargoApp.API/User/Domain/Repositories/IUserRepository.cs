using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.User.Domain.Repositories;

public interface IUserRepository : IBaseRepository<Model.Aggregates.User>
{
    
}