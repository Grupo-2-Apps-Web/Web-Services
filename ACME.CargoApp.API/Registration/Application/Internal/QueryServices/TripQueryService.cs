using ACME.CargoApp.API.Registration.Domain.Model.Aggregates;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class TripQueryService(ITripRepository tripRepository, IEvidenceRepository evidenceRepository, IAlertRepository alertRepository, IOngoingTripRepository ongoingTripRepository)
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

    public async Task<IEnumerable<Alert>> Handle(GetAlertsByTripIdQuery query)
    { 
        return await alertRepository.FindByTripIdAsync(query.TripId);
    }
    
    public async Task<IEnumerable<OngoingTrip>> Handle(GetOngGoingTripByIdQuery query)
    { 
        return await ongoingTripRepository.FindOngoingByTripIdAsync(query.TripId);
    }
    public async Task<IEnumerable<Driver>> Handle(GetDriversByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindDriversByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    public async Task<IEnumerable<Vehicle>> Handle(GetVehiclesByEntrepreneurIdQuery query)
    {
        return await tripRepository.FindVehiclesByEntrepreneurIdAsync(query.EntrepreneurId);
    }
    
}

