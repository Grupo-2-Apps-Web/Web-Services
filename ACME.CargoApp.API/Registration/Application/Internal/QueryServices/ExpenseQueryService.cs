using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class ExpenseQueryService(IExpenseRepository expenseRepository)
    : IExpenseQueryService
{
    public async Task<Expense?> Handle(GetExpenseByIdQuery query)
    {
        return await expenseRepository.FindByIdAsync(query.ExpenseId);
    }
    
    public async Task<IEnumerable<Expense>> Handle(GetAllExpensesQuery query)
    {
        return await expenseRepository.ListAsync();
    }
}