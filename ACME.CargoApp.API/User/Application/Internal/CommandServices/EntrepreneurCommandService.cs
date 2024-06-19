using ACME.CargoApp.API.IAM.Domain.Repositories;
using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.CommandServices;

public class EntrepreneurCommandService(IEntrepreneurRepository entrepreneurRepository, IUserRepository userRepository, IUnitOfWork unitOfWork): IEntrepreneurCommandService
{
    public async Task<Entrepreneur?> Handle(CreateEntrepreneurCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
        {
            throw new ArgumentException("UserId not found.");
        }
        // Create the entrepreneur
        var entrepreneur = new Entrepreneur(command, user);
        try
        {
            await entrepreneurRepository.AddAsync(entrepreneur);
            await unitOfWork.CompleteAsync();
            return entrepreneur;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the entrepreneur: {e.Message}");
            return null;
        }
    }
}