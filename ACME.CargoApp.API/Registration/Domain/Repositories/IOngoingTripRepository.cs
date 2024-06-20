using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Domain.Repositories;
namespace ACME.CargoApp.API.Registration.Domain.Repositories;

public interface IOngoingTripRepository : IBaseRepository<OngoingTrip>
{
    Task<OngoingTrip?> FindByTripIdAsync(int tripId);
    
    Task<IEnumerable<OngoingTrip>> FindOngoingByTripIdAsync(int tripId);
}