using ACME.CargoApp.API.IAM.Domain.Model.Queries;
using ACME.CargoApp.API.IAM.Domain.Repositories;
using ACME.CargoApp.API.IAM.Domain.Services;

namespace ACME.CargoApp.API.IAM.Application.Internal.QueryServices;

/**
 * <summary>
 *     The user query service implementation class
 * </summary>
 * <remarks>
 *     This class is used to handle user queries
 * </remarks>
 */
public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    /**
     * <summary>
     *     Handle get user by id query
     * </summary>
     * <param name="query">The query object containing the user id to search</param>
     * <returns>The user</returns>
     */
    public async Task<Domain.Model.Aggregates.User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.Id);
    }

    /**
     * <summary>
     *     Handle get user by username query
     * </summary>
     * <param name="query">The query object for getting all users</param>
     * <returns>The user</returns>
     */
    public async Task<IEnumerable<Domain.Model.Aggregates.User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    /**
     * <summary>
     *     Handle get user by username query
     * </summary>
     * <param name="query">The query object containing the username to search</param>
     * <returns>The user</returns>
     */
    public async Task<Domain.Model.Aggregates.User?> Handle(GetUserByUsernameQuery query)
    {
        return await userRepository.FindByUsernameAsync(query.Username);
    }
}