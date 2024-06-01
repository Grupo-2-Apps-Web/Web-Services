using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(Domain.Model.Aggregates.User entity)
    {
        return new UserResource(entity.Id, entity.UserData, entity.UserAuthentication, entity.SubscriptionPlan);
    }
}