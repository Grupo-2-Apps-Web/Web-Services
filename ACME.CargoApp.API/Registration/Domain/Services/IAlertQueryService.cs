using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IAlertQueryService
{
    Task<Alert?> Handle(GetAlertByIdQuery query);
    Task<IEnumerable<Alert>> Handle(GetAllAlertsQuery query);
}