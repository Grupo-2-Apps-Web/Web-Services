﻿using ACME.CargoApp.API.User.Domain.Model.Commands;
using ACME.CargoApp.API.User.Interfaces.REST.Resources;

namespace ACME.CargoApp.API.User.Interfaces.REST.Transform;

public static class CreateEntrepreneurCommandFromResourceAssembler
{
    public static CreateEntrepreneurCommand ToCommandFromResource(CreateEntrepreneurResource resource)
    {
        return new CreateEntrepreneurCommand(resource.UserId, resource.LogoIma);
    }
}