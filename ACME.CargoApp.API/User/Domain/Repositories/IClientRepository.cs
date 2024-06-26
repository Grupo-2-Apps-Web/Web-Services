﻿using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Model.Entities;

namespace ACME.CargoApp.API.User.Domain.Repositories;

public interface IClientRepository : IBaseRepository<Client>
{
    Task<Client?> FindByUserIdAsync(int userId);
}