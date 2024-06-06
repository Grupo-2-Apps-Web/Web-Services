
using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ACME.CargoApp.API.User.Domain.Model.Entities;
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
    
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Evidence> Evidences { get; set; }

    public DbSet<OngoingTrip> OngoingTrips { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Registration Context
        
        //Driver Table
        builder.Entity<Driver>().HasKey(d => d.Id);
        builder.Entity<Driver>().Property(d => d.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Driver>().Property(d => d.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Driver>().Property(d => d.Dni).IsRequired().HasMaxLength(8);
        builder.Entity<Driver>().Property(d => d.License).IsRequired().HasMaxLength(10);
        builder.Entity<Driver>().Property(d => d.ContactNumber).IsRequired().HasMaxLength(9);
        
        //Vehicle Table
        builder.Entity<Vehicle>().HasKey(v => v.Id);
        builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Vehicle>().Property(v => v.Model).IsRequired().HasMaxLength(100);
        builder.Entity<Vehicle>().Property(v => v.TractorPlate).IsRequired().HasMaxLength(100);
        builder.Entity<Vehicle>().Property(v => v.MaxLoad).IsRequired().HasPrecision(6, 2);
        builder.Entity<Vehicle>().Property(v => v.Volume).IsRequired().HasPrecision(6, 2);
        
        //Trip Table
        builder.Entity<Trip>().HasKey(t => t.Id);
        builder.Entity<Trip>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Trip>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.TripName).HasColumnName("Name");
            });
        builder.Entity<Trip>().OwnsOne(p => p.CargoData,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(p => p.Type).HasColumnName("Type");
                c.Property(p => p.Weight).HasColumnName("Weight");
            });
        
        builder.Entity<Trip>().OwnsOne(p => p.TripData,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(p => p.LoadLocation).HasColumnName("LoadLocation");
                c.Property(p => p.LoadDate).HasColumnName("LoadDate");
                c.Property(p => p.UnloadLocation).HasColumnName("UnloadLocation");
                c.Property(p => p.UnloadDate).HasColumnName("UnloadDate");
            });
        
        //Expense Table
        builder.Entity<Expense>().HasKey(e => e.Id);
        builder.Entity<Expense>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Expense>().Property(e => e.FuelAmount).IsRequired();
        builder.Entity<Expense>().Property(e => e.FuelDescription).IsRequired();
        builder.Entity<Expense>().Property(e => e.ViaticsAmount).IsRequired();
        builder.Entity<Expense>().Property(e => e.ViaticsDescription).IsRequired();
        builder.Entity<Expense>().Property(e => e.TollsAmount).IsRequired();
        builder.Entity<Expense>().Property(e => e.TollsDescription).IsRequired();
        
        //Evidence Table
        builder.Entity<Evidence>().HasKey(ev => ev.Id);
        builder.Entity<Evidence>().Property(ev => ev.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Evidence>().Property(ev => ev.Link).IsRequired().HasMaxLength(200);
        
        //Alert Table
        builder.Entity<Alert>().HasKey(a => a.Id);
        builder.Entity<Alert>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Alert>().Property(a => a.Title).IsRequired().HasMaxLength(20);
        builder.Entity<Alert>().Property(a => a.Description).IsRequired();
        builder.Entity<Alert>().Property(a => a.Date).IsRequired();
        
        //OngoingTrip Table
        builder.Entity<OngoingTrip>().HasKey(ot => ot.Id);
        builder.Entity<OngoingTrip>().Property(ot => ot.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<OngoingTrip>().Property(ot => ot.Latitude).IsRequired();
        builder.Entity<OngoingTrip>().Property(ot => ot.Longitude).IsRequired();
        builder.Entity<OngoingTrip>().Property(ot => ot.Speed).IsRequired();
        builder.Entity<OngoingTrip>().Property(ot => ot.Distance).IsRequired();
        
        //Trips Table Relationships
        builder.Entity<Trip>()
            .HasOne(t => t.Driver)
            .WithMany(d => d.Trips)
            .HasForeignKey(t => t.DriverId)
            .HasPrincipalKey(d => d.Id);
        
        builder.Entity<Trip>()
            .HasOne(t => t.Vehicle)
            .WithMany(v => v.Trips)
            .HasForeignKey(t => t.VehicleId)
            .HasPrincipalKey(v => v.Id);
        
        builder.Entity<Trip>()
            .HasOne(t => t.Client)
            .WithMany(c => c.Trips)
            .HasForeignKey(t => t.ClientId)
            .HasPrincipalKey(c => c.Id);
        
        builder.Entity<Trip>()
            .HasOne(t => t.Entrepreneur)
            .WithMany(e => e.Trips)
            .HasForeignKey(t => t.EntrepreneurId)
            .HasPrincipalKey(e => e.Id);
        
        
        //Expenses Table Relationships
        builder.Entity<Expense>()
            .HasOne(e => e.Trip)
            .WithOne(t => t.Expense)
            .HasForeignKey<Expense>(e => e.TripId)
            .HasPrincipalKey<Trip>(t => t.Id);
        
        //Evidences Table Relationships
        builder.Entity<Evidence>()
            .HasOne(ev => ev.Trip)
            .WithOne(t => t.Evidence)
            .HasForeignKey<Evidence>(ev => ev.TripId)
            .HasPrincipalKey<Trip>(t => t.Id);
        
        //Alerts Table Relationships
        builder.Entity<Alert>()
            .HasOne(a => a.Trip)
            .WithOne(t => t.Alert)
            .HasForeignKey<Alert>(a => a.TripId)
            .HasPrincipalKey<Trip>(t => t.Id);
        
        //OngoingTrips Table Relationships
        builder.Entity<OngoingTrip>()
            .HasOne(ot => ot.Trip)
            .WithOne(t => t.OngoingTrip)
            .HasForeignKey<OngoingTrip>(ot => ot.TripId)
            .HasPrincipalKey<Trip>(t => t.Id);
        
        // User Context
        
        //User Table
        builder.Entity<User.Domain.Model.Aggregates.User>().HasKey(u => u.Id);
        builder.Entity<User.Domain.Model.Aggregates.User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User.Domain.Model.Aggregates.User>().OwnsOne(u => u.UserData,
            d =>
            {
                d.WithOwner().HasForeignKey("Id");
                d.Property(u => u.Name).HasColumnName("Name");
                d.Property(u => u.Phone).HasColumnName("Phone");
                d.Property(u => u.Ruc).HasColumnName("Ruc");
                d.Property(u => u.Address).HasColumnName("Address");
            });
        builder.Entity<User.Domain.Model.Aggregates.User>().OwnsOne(u => u.UserAuthentication,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(u => u.Email).HasColumnName("Email");
                a.Property(u => u.Password).HasColumnName("Password");
            });
        builder.Entity<User.Domain.Model.Aggregates.User>().OwnsOne(u => u.SubscriptionPlan,
            s =>
            {
                s.WithOwner().HasForeignKey("Id");
                s.Property(u => u.Subscription).HasColumnName("Subscription");
            });
        
        //Client table
        builder.Entity<Client>().HasKey(c => c.Id);
        builder.Entity<Client>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        
        //Client table relationships
        builder.Entity<Client>()
            .HasOne(c => c.User)
            .WithOne(u => u.Client)
            .HasForeignKey<Client>(c => c.UserId)
            .HasPrincipalKey<User.Domain.Model.Aggregates.User>(u => u.Id);
        
       
        //Entrepreneur table
        builder.Entity<Entrepreneur>().HasKey(e => e.Id);
        builder.Entity<Entrepreneur>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Entrepreneur>().Property(e => e.LogoImage).IsRequired().HasMaxLength(100);
        
        //Entrepreneur table relationships

        builder.Entity<Entrepreneur>()
            .HasOne(e => e.User)
            .WithOne(u => u.Entrepreneur)
            .HasForeignKey<Entrepreneur>(e => e.UserId)
            .HasPrincipalKey<User.Domain.Model.Aggregates.User>(u => u.Id);
        
        // Configuration table
        
       builder.Entity<User.Domain.Model.Entities.Configuration>().HasKey(c => c.Id);
       builder.Entity<User.Domain.Model.Entities.Configuration>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
       builder.Entity<User.Domain.Model.Entities.Configuration>().Property(c => c.Theme).IsRequired().HasMaxLength(100);
       builder.Entity<User.Domain.Model.Entities.Configuration>().Property(c => c.View).IsRequired().HasMaxLength(100);
       builder.Entity<User.Domain.Model.Entities.Configuration>().Property(c => c.AllowDataCollection).IsRequired();
       builder.Entity<User.Domain.Model.Entities.Configuration>().Property(c => c.UpdateDataSharing).IsRequired();
        
       // Configuration table relationships
       
       builder.Entity<User.Domain.Model.Entities.Configuration>()
           .HasOne(c => c.User)
           .WithOne(u => u.Configuration)
           .HasForeignKey<User.Domain.Model.Entities.Configuration>(c => c.UserId)
           .HasPrincipalKey<User.Domain.Model.Aggregates.User>(u => u.Id);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}