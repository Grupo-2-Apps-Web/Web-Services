using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Commands;

namespace ACME.CargoApp.API.User.Domain.Services;

public interface IUserCommandService
{
    Task<Domain.Model.Aggregates.User?> Handle(CreateUserCommand createUserCommand);
    Task<Domain.Model.Aggregates.User?> Handle(UpdateUserCommand updateUserCommand);
}