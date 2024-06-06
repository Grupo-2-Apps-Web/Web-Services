using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.User.Domain.Model.Aggregates;
using ACME.CargoApp.API.User.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.User.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<Domain.Model.Aggregates.User>(context), IUserRepository;