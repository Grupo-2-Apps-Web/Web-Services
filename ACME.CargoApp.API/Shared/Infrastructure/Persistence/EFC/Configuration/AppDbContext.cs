
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Registration Context
        // ...
        
        // User Context
        // ...
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}