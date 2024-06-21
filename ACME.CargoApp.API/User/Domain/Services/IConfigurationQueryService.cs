﻿using ACME.CargoApp.API.User.Domain.Model.Entities;
using ACME.CargoApp.API.User.Domain.Model.Queries;
namespace ACME.CargoApp.API.User.Domain.Services;

public interface IConfigurationQueryService
{
    Task<IEnumerable<Configuration>> Handle(GetAllConfigurationsQuery query);
    Task<Configuration?> Handle(GetConfigurationByIdQuery query);
    Task<Configuration?> Handle(GetConfigurationByUserIdQuery query);
}