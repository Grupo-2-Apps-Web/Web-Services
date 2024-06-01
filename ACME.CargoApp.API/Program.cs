using ACME.CargoApp.API.Registration.Application.Internal.CommandServices;
using ACME.CargoApp.API.Registration.Application.Internal.QueryServices;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Registration.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.Shared.Domain.Repositories;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ACME.CargoApp.API.Shared.Interfaces.ASP.Configuration;
using ACME.CargoApp.API.User.Application.Internal.CommandServices;
using ACME.CargoApp.API.User.Application.Internal.QueryServices;
using ACME.CargoApp.API.User.Domain.Repositories;
using ACME.CargoApp.API.User.Domain.Services;
using ACME.CargoApp.API.User.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",new OpenApiInfo
            {
                Title = "ACME.CargoApp.API",
                Version = "v1",
                Description = "ACME Cargo App API",
                TermsOfService = new Uri("https://acme-cargo.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "ACME Studios",
                    Email = "contact@acme.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            }
            );
        c.EnableAnnotations();
    });

// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Registration Bounded Context Injection Configuration
//Repositories
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
//Commands
builder.Services.AddScoped<IDriverCommandService, DriverCommandService>();
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();
//Queries
builder.Services.AddScoped<IDriverQueryService, DriverQueryService>();
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();

// User Bounded Context Injection Configuration
// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Commands
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
// Queries
builder.Services.AddScoped<IUserQueryService, UserQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();