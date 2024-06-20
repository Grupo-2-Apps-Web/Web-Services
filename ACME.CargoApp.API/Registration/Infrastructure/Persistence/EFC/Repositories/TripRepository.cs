﻿using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.Registration.Infrastructure.Persistence.EFC.Repositories;

public class TripRepository : BaseRepository<Trip>, ITripRepository
{
    private readonly AppDbContext _context;
    
    public TripRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Trip>> FindByClientIdAsync(int clientId)
    {
        return await _context.Trips.Where(t => t.ClientId == clientId).ToListAsync();
    }
    
    public async Task<IEnumerable<Trip>> FindByEntrepreneurIdAsync(int entrepreneurId)
    {
        return await _context.Trips.Where(t => t.EntrepreneurId == entrepreneurId).ToListAsync();
    }
    
}