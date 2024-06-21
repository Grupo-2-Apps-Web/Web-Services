using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class TripQueryService(ITripRepository tripRepository, IEvidenceRepository evidenceRepository, IAlertRepository alertRepository, IOngoingTripRepository ongoingTripRepository, IExpenseRepository expenseRepository)
    : ITripQueryService
{
    public async Task<Trip?> Handle(GetTripByIdQuery query)
    {
        return await tripRepository.FindByIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<Trip>> Handle(GetAllTripsQuery query)
    {
        return await tripRepository.ListAsync();
    }
    public async Task<Evidence?> Handle(GetEvidencesByTripIdQuery query)
    {
        return await evidenceRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<Expense?> Handle(GetExpensesByTripIdQuery query)
    {
        return await expenseRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<Alert>> Handle(GetAlertsByTripIdQuery query)
    { 
        return await alertRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<OngoingTrip>> Handle(GetOngGoingTripByIdQuery query)
    { 
        return await ongoingTripRepository.FindOngoingByTripIdAsync(query.TripId);
    }
    
    
    public async Task<IEnumerable<Trip>> Handle(GetTripsByClientIdQuery query)
    {
        return await tripRepository.FindByClientIdAsync(query.ClientId);
    }
    
    public async Task<IEnumerable<Trip>> Handle(GetTripsByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    
    
    
    
}

