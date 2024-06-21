using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.User.Infrastructure.Persistence.EFC.Repositories;

public class ClientRepository(AppDbContext context) 
    : BaseRepository<Client>(context), IClientRepository
{
    public async Task<Client?> FindByUserIdAsync(int userId)
    {
        return await context.Clients.FirstOrDefaultAsync(c => c.UserId == userId);
    }
}