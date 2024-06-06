using ACME.CargoApp.API.Registration.Domain.Model.Entities;
using ACME.CargoApp.API.Registration.Domain.Model.Queries;
using ACME.CargoApp.API.Registration.Domain.Repositories;
using ACME.CargoApp.API.Registration.Domain.Services;

namespace ACME.CargoApp.API.Registration.Application.Internal.QueryServices;

public class EvidenceQueryService(IEvidenceRepository evidenceRepository)
    : IEvidenceQueryService
{
    public async Task<Evidence?> Handle(GetEvidenceByIdQuery query)
    {
        return await evidenceRepository.FindByIdAsync(query.EvidenceId);
    }
    
    public async Task<IEnumerable<Evidence>> Handle(GetAllEvidencesQuery query)
    {
        return await evidenceRepository.ListAsync();
    }
}