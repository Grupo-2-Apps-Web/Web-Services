using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.Entities;

namespace ACME.CargoApp.API.User.Domain.Services;

public interface IConfigurationCommandService
{
    Task<Configuration?> Handle(CreateConfigurationCommand createConfigurationCommand);
    Task<Configuration?> Handle(UpdateConfigurationCommand updateConfigurationCommand);
}