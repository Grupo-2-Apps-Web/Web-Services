﻿using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.User.Infrastructure.Persistence.EFC.Repositories;

public class ConfigurationRepository(AppDbContext context)
    : BaseRepository<Configuration>(context), IConfigurationRepository
{
    public async Task<Configuration?> FindByUserIdAsync(int userId)
    {
        return await context.Configurations.FirstOrDefaultAsync(c => c.UserId == userId);
    }
}
