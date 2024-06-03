﻿using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.CargoApp.API.Registration.Infrastructure;

public class OngoingTripRepository (AppDbContext context) : BaseRepository<OngoingTrip>(context), IOngoingTripRepository;