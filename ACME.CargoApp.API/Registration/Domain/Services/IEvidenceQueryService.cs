using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;

namespace ACME.CargoApp.API.Registration.Domain.Services;

public interface IEvidenceQueryService
{
    Task<Evidence?> Handle(GetEvidenceByIdQuery query);
    Task<IEnumerable<Evidence>> Handle(GetAllEvidencesQuery query);
    
}