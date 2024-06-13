using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.User.Infrastructure.Persistence.EFC.Repositories;

public class EntrepreneurRepository(AppDbContext context)
    : BaseRepository<Entrepreneur>(context), IEntrepreneurRepository
{
    public async Task<Entrepreneur?> FindByUserIdAsync(int userId)
    {
        return await context.Entrepreneurs.FirstOrDefaultAsync(e => e.UserId == userId);
    }
}
