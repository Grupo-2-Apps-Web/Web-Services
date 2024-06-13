using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Entities;

namespace ACME.CargoApp.API.User.Domain.Repositories;

public interface IEntrepreneurRepository : IBaseRepository<Entrepreneur>
{
    Task<Entrepreneur?> FindByUserIdAsync(int userId);
}