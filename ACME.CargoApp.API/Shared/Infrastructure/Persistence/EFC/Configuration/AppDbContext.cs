
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
        builder.Entity<Entrepreneur>().Property(e => e.LogoIma).IsRequired().HasMaxLength(100);
        
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