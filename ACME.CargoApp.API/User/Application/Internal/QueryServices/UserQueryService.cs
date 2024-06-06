using ACME.CargoApp.API.User.Domain.Model.Queries;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;

namespace ACME.CargoApp.API.User.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
    
    public async Task<Domain.Model.Aggregates.User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
}