using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class CreateExpenseCommandFromResourceAssembler
{
    public static CreateExpenseCommand ToCommandFromResource(CreateExpenseResource resource)
    {
        return new CreateExpenseCommand(resource.FuelAmount, resource.FuelDescription, resource.ViaticsAmount,
            resource.ViaticsDescription, resource.TollsAmount, resource.TollsDescription, resource.TripId);
    }
}