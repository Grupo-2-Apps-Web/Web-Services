﻿namespace ACME.CargoApp.API.Registration.Domain.Model.Commands;

public record CreateOngoingTripCommand(float Latitude, float Longitude, int Speed, int Distance, int TripId);