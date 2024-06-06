using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.ValueObjects;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork) : IUserCommandService
{
    public async Task<Domain.Model.Aggregates.User?> Handle(CreateUserCommand command)
    {
        if (command.Subscription != "Basic" && command.Subscription != "Premium")
        {
            throw new ArgumentException("Subscription is not valid.");
        }
        try
        {
            var user = new Domain.Model.Aggregates.User(command.Name, command.Phone, command.Ruc, command.Address,
                command.Email, command.Password, command.Subscription);
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the user: {e.Message}");
            return null;
        }
    }
    
    public async Task<Domain.Model.Aggregates.User?> Handle(UpdateUserCommand command)
    {
        if (command.Subscription != "Basic" && command.Subscription != "Premium")
        {
            throw new ArgumentException("Subscription is not valid.");
        }
        
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
        {
            return null;
        }
        
        // Update the user information
        user.UserData = new UserData(command.Name, command.Phone, command.Ruc, command.Address);
        user.UserAuthentication = new UserAuthentication(command.Email, command.Password);
        user.SubscriptionPlan = new SubscriptionPlan(command.Subscription);
        
        await unitOfWork.CompleteAsync();
        return user;
    }
    
}