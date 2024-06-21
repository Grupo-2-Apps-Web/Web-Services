using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Domain.Repositories;
 

namespace ACME.CargoApp.API.Registration.Domain.Repositories;
public interface IExpenseRepository : IBaseRepository<Expense>
{ 
    Task<Expense?> FindByTripIdAsync(int tripId);

}
