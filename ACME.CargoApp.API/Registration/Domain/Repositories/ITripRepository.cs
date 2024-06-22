using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;

namespace ACME.CargoApp.API.Registration.Domain.Repositories;

public interface ITripRepository: IBaseRepository<Trip>
{
    Task<IEnumerable<Driver>> FindDriversByEntrepreneurIdAsync(int entrepreneurId);
    Task<IEnumerable<Vehicle>> FindVehiclesByEntrepreneurIdAsync(int entrepreneurId);
    Task<IEnumerable<Trip>> FindByClientIdAsync(int clientId);
    Task<IEnumerable<Trip>> FindByEntrepreneurIdAsync(int entrepreneurId);
    Task<IEnumerable<Client>> FindClientsByEntrepreneurIdAsync(int entrepreneurId);
}