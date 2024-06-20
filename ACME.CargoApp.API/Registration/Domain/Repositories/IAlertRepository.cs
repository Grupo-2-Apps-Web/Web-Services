using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Domain.Repositories;

public interface IAlertRepository : IBaseRepository<Alert>
{ 
    Task<IEnumerable<Alert>> FindByTripIdAsync(int tripId);
}