﻿using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;
using ACME.CargoApp.API.Shared.Domain.Repositories;
namespace ACME.CargoApp.API.Registration.Application.Internal.CommandServices;

public class OngoingTripCommandService(IOngoingTripRepository ongoingTripRepository, ITripRepository tripRepository, IUnitOfWork unitOfWork)
    :IOngoingTripCommandService
{
    public async Task<OngoingTrip?> Handle(CreateOngoingTripCommand command)
    {
        // Additional validation to check if the trip exists
        var trip = await tripRepository.FindByIdAsync(command.TripId);
        if (trip == null)
        {
            throw new ArgumentException("TripId not found.");
        }

        var ongoingTrip = new OngoingTrip(command.Latitude, command.Longitude, command.Speed, command.Distance, command.TripId);
        await ongoingTripRepository.AddAsync(ongoingTrip);
        await unitOfWork.CompleteAsync();
        return ongoingTrip;
    }
    
    public async Task<OngoingTrip?> Handle(UpdateOngoingTripCommand command)
    {
        var ongoingTrip = await ongoingTripRepository.FindByIdAsync(command.TripId);
        if (ongoingTrip == null)
        {
            return null;
        }
        //Update the ongoingTrip information
        ongoingTrip.Latitude = command.Latitude;
        ongoingTrip.Longitude = command.Longitude;
        ongoingTrip.Speed = command.Speed;
        ongoingTrip.Distance = command.Distance;
        
        await unitOfWork.CompleteAsync();
        return ongoingTrip;
    }
}