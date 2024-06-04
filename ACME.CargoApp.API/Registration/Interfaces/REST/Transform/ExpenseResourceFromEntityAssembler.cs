using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class ExpenseResourceFromEntityAssembler
{
    public static ExpenseResource ToResourceFromEntity(Expense entity)
    {
        return new ExpenseResource(entity.Id, entity.FuelAmount, entity.FuelDescription, entity.ViaticsAmount,
            entity.ViaticsDescription, entity.TollsAmount, entity.TollsDescription, entity.TripId);
    }
}