using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Domain.Model.Entities;

namespace ACME.CargoApp.API.User.Domain.Services;

public interface IClientCommandService
{
    Task<Client?> Handle(CreateClientCommand createClientCommand);
}