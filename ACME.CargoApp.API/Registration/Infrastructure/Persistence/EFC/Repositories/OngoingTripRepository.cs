using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ACME.CargoApp.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ACME.CargoApp.API.Registration.Infrastructure;

public class OngoingTripRepository : BaseRepository<OngoingTrip>, IOngoingTripRepository
{
    private readonly AppDbContext _context;

    public OngoingTripRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<OngoingTrip?> FindByTripIdAsync(int tripId)
    {
        return await _context.OngoingTrips.FirstOrDefaultAsync(e => e.TripId == tripId);
    }
    
    public async Task<IEnumerable<OngoingTrip>> FindOngoingByTripIdAsync(int tripId)
    {
        return await _context.OngoingTrips.Where(e => e.TripId == tripId).ToListAsync();
    }
     
}