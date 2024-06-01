using ACME.CargoApp.API.User.Domain.Model.ValueObjects;

namespace ACME.CargoApp.API.User.Interfaces.REST.Resources;

public record UserResource(int Id, UserData UserData, UserAuthentication UserAuthentication, SubscriptionPlan SubscriptionPlan);