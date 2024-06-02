using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.CargoApp.API.Registration.Infrastructure.Persistence.EFC.Repositories;

public class AlertRepository (AppDbContext context) : BaseRepository<Alert>(context), IAlertRepository;