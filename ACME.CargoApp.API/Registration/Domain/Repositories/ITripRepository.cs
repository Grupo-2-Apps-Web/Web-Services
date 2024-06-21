﻿using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Domain.Repositories;

namespace ACME.CargoApp.API.Registration.Domain.Repositories;

public interface ITripRepository: IBaseRepository<Trip>
{
    Task<IEnumerable<Driver>> FindDriversByEntrepreneurIdAsync(int entrepreneurId);
}