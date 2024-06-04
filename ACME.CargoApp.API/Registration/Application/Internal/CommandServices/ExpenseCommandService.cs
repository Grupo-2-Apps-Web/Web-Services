 using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
 using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class ExpenseCommandService(IExpenseRepository expenseRepository ,ITripRepository tripRepository, IUnitOfWork unitOfWork)
    : IExpenseCommandService
{
    public async Task<Expense?> Handle(CreateExpenseCommand command)
    {
        // Additional validation to check if the trip exists
        var trip = await tripRepository.FindByIdAsync(command.TripId);
        if (trip == null)
        {
            throw new ArgumentException("TripId not found.");
        }

        var expense = new Expense(command, trip);
        await expenseRepository.AddAsync(expense);
        await unitOfWork.CompleteAsync();
        return expense;
    }
    
    public async Task<Expense?> Handle(UpdateExpenseCommand command)
    {
        var expense = await expenseRepository.FindByIdAsync(command.TripId);
        if (expense == null)
        {
            return null;
        }
        //Update the expense information
        expense.ViaticsAmount = command.ViaticsAmount;
        expense.ViaticsDescription = command.ViaticsDescription;
        expense.FuelAmount = command.FuelAmount;
        expense.FuelDescription = command.FuelDescription;
        expense.TollsAmount = command.TollsAmount;
        expense.TollsDescription = command.TollsDescription;
        
        await unitOfWork.CompleteAsync();
        return expense;
    }
    
    
}
 