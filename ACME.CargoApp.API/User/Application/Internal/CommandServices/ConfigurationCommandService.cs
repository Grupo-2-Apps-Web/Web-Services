using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.CommandServices;

public class ConfigurationCommandService (IConfigurationRepository configurationRepository, IUserRepository userRepository, IUnitOfWork unitOfWork) : IConfigurationCommandService
{
    public async Task<Configuration?> Handle(CreateConfigurationCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null)
        {
            throw new ArgumentException("UserId not found.");
        }
        // Create the configuration
        var configuration = new Configuration(command.UserId, user)
        {
            Theme = command.Theme,
            View = command.View,
            AllowDataCollection = command.AllowDataCollection,
            UpdateDataSharing = command.UpdateDataSharing
        };
        
        try
        {
            await configurationRepository.AddAsync(configuration);
            await unitOfWork.CompleteAsync();
            return configuration;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the configuration: {e.Message}");
            return null;
        }
    }
    
    public async Task<Configuration?> Handle(UpdateConfigurationCommand command)
    {
        var configuration = await configurationRepository.FindByIdAsync(command.ConfigurationId);
        
        if (configuration == null)
        {
            return null;
        }
        
        // Update the configuration information
        
        configuration.Theme = command.Theme;
        configuration.View = command.View;
        configuration.AllowDataCollection = command.AllowDataCollection;
        configuration.UpdateDataSharing = command.UpdateDataSharing;
        
        await unitOfWork.CompleteAsync();
        return configuration;
    }
}