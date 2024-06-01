using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Queries;

namespace ACME.CargoApp.API.User.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<Domain.Model.Aggregates.User>> Handle(GetAllUsersQuery query);
    Task<Domain.Model.Aggregates.User?> Handle(GetUserByIdQuery query);
}