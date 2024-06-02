﻿using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.Registration.Interfaces.REST.Transform;

public static class CreateTripCommandFromResourceAssembler
{
    public static CreateTripCommand ToCommandFromResource(CreateTripResource resource)
    {
        return new CreateTripCommand(resource.Name, resource.Type, resource.Weight, resource.LoadLocation, resource.LoadDate,
            resource.UnloadLocation, resource.UnloadDate, resource.DriverId, resource.VehicleId);
    }
}