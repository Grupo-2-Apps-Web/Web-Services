using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.ValueObjects;

namespace ACME.CargoApp.API.User.Domain.Model.Aggregates;

public class User
{
    public User()
    {
        UserData = new UserData();
        UserAuthentication = new UserAuthentication();
        SubscriptionPlan = new SubscriptionPlan();
    }
    

    public User(string name, string phone, string ruc, string address, string email, string password, string subscription)
    {
        UserData = new UserData(name, phone, ruc, address);
        UserAuthentication = new UserAuthentication(email, password);
        SubscriptionPlan = new SubscriptionPlan(subscription);
    }

    public User(CreateUserCommand command)
    {
        UserData = new UserData(command.Name, command.Phone, command.Ruc, command.Address);
        UserAuthentication = new UserAuthentication(command.Email, command.Password);
        SubscriptionPlan = new SubscriptionPlan(command.Subscription);
    }
    
    public int Id { get; set; }
    public UserData UserData { get; internal set; }
    public UserAuthentication UserAuthentication { get; internal set; }
    public SubscriptionPlan SubscriptionPlan { get; internal set; }
    
}