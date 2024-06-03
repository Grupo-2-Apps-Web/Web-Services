using ACME.CargoApp.API.Registration.Domain.Model.Commands;
using ACME.CargoApp.API.Registration.Domain.Model.Entities;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IEvidenceCommandService
{
    Task<Evidence?> Handle(CreateEvidenceCommand createTripCommand);
    Task<Evidence?> Handle(UpdateEvidenceCommand updateTripCommand);
}