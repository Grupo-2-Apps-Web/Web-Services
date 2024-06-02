using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IExpenseQueryService
{
    Task<Expense?> Handle(GetExpenseByIdQuery query);
    Task<IEnumerable<Expense>> Handle(GetAllExpensesQuery query);
}