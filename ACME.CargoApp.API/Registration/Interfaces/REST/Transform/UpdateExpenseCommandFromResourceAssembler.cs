using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class UpdateExpenseCommandFromResourceAssembler
{
    public static UpdateExpenseCommand ToCommandFromResource(UpdateExpenseResource resource, int expenseId)
    {
        return new UpdateExpenseCommand(expenseId, resource.FuelAmount, resource.FuelDescription, resource.ViaticsAmount, resource.ViaticsDescription,
            resource.TollsAmount, resource.TollsDescription, resource.TripId);
    }
}