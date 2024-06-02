﻿
using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
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
        
        // User Context
        // ...
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}