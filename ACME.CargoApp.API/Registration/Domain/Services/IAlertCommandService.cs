using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IAlertCommandService
{
    Task<Alert?> Handle(CreateAlertCommand createAlertCommand);
}