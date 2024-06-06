namespace ACME.CargoApp.API.User.Domain.Model.ValueObjects;

public record SubscriptionPlan(string Subscription)
{
    public SubscriptionPlan() : this(string.Empty)
    {
    }
}