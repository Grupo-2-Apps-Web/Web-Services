using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IDriverQueryService
{
    Task<Driver?> Handle(GetDriverByIdQuery query);
    Task<IEnumerable<Driver>> Handle(GetAllDriversQuery query);
}